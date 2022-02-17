using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoleculeOSSite.Entities;
using MoleculeOSSite.Models.DTOs;
using MoleculeOSSite.Services;

namespace MoleculeOSSite.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AuthController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("users")]
        public ActionResult RegisterUser([FromBody]RegisterDTO registerDto)
        {
            _accountService.RegisterUser(registerDto);
            return Ok();
        }

        [HttpPost("tokens")]
        public ActionResult Login([FromBody]LoginDTO loginDto)
        {
            string token = _accountService.GenerateJwt(loginDto);
            
            return Ok(new { token });
        }
    }
}
