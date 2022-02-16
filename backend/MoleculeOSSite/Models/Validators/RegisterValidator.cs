using FluentValidation;
using MoleculeOSSite.Entities;
using MoleculeOSSite.Models.DTOs;

namespace MoleculeOSSite.Models.Validators
{
    public class RegisterValidator:AbstractValidator<RegisterDTO>
    {
        public RegisterValidator(MyDbContext dbcontext)
        {
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Password).NotEmpty().MinimumLength(6);
            RuleFor(x => x.ConfirmPassword).Equal(u => u.Password);
            RuleFor(x => x.Email).Custom((value, context) =>
            {
                var emailExist = dbcontext.Users.Any(u => u.Email == value);
                if (emailExist)
                    context.AddFailure(nameof(User.Email), "Email is already taken");
            });
            RuleFor(x => x.Username).Custom((value, context) =>
            {
                var usernameExist = dbcontext.Users.Any(u => u.Username == value);
                if (usernameExist)
                    context.AddFailure(nameof(User.Username), "User with given username already exist");
            });
        }
    }
}
