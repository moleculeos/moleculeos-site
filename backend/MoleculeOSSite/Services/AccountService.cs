using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MoleculeOSSite.Entities;
using MoleculeOSSite.Models.DTOs;
using MoleculeOSSite.ModelsDTO;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MoleculeOSSite.Services
{
    public interface IAccountService
    {
        void RegisterUser(RegisterDTO registerDto);
        string GenerateJwt(LoginDTO loginDto);
    }


    public class AccountService : IAccountService
    {
        private readonly MyDbContext _context;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly AuthenticationSettings _authenticationSettings;

        public AccountService(MyDbContext context, IPasswordHasher<User> passwordHasher,
            AuthenticationSettings authenticationSettings)
        {
            _context = context;
            _passwordHasher = passwordHasher;
            _authenticationSettings = authenticationSettings;
        }

        public User CheckLogin(LoginDTO loginDto)
        {
            var user = _context.Users
                .Include(u => u.Role)
                .FirstOrDefault(u => u.Email == loginDto.Login || u.Username == loginDto.Login);

            if (user == null)
                throw new BadHttpRequestException("Invalid username or password");

            var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, loginDto.Password);
            if (result == PasswordVerificationResult.Failed)
                throw new BadHttpRequestException("Invalid username or password");

            else
                return user;
        }

        public string GenerateJwt(LoginDTO loginDto)
        {
            var user = CheckLogin(loginDto);

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name ,$"{user.Email} {user.Username}"),
                new Claim(ClaimTypes.Role, $"{user.Role.Name}"),
                new Claim(nameof(User.JoinDate), user.JoinDate.ToString("yyyy-MM-dd"))
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationSettings.JwtKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(_authenticationSettings.JwtExpireDays);

            var token = new JwtSecurityToken(_authenticationSettings.JwtIssuer,
                _authenticationSettings.JwtIssuer,
                claims,
                expires:expires,
                signingCredentials:credentials);

            var tokenHandler = new JwtSecurityTokenHandler();

            return tokenHandler.WriteToken(token);
        }

        public void RegisterUser(RegisterDTO registerDto)
        {
            var newUser = new User();
            newUser.Username = registerDto.Username;
            newUser.Email = registerDto.Email;
            newUser.JoinDate = DateTime.Now;
            newUser.PasswordHash = _passwordHasher.HashPassword(newUser, registerDto.Password);

            _context.Users.Add(newUser);
            _context.SaveChanges();   
        }
    }
}
