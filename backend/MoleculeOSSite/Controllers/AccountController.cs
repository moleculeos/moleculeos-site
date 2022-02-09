using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoleculeOSSite.Entities;
using MoleculeOSSite.ModelsDTO;
using MoleculeOSSite.Services;

namespace MoleculeOSSite.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }


        [HttpPost("register")]
        public ActionResult RegisterUser([FromBody]User user)
        {
            _accountService.RegisterUser(user);

            return Ok();
        }

        [HttpPost("login")]
        public ActionResult Login([FromBody]LoginDTO dto)
        {
            string token = _accountService.GenerateJwt(dto);

            return Ok(token);
        }
    }
}
