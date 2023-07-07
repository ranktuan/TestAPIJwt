using Microsoft.AspNetCore.Mvc;
using MinvoiceWebhook.Models;
using MinvoiceWebhook.Services;



namespace MinvoiceWebhook.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserLoginController : ControllerBase
    {
        private readonly ITokenService _tokenService;

        public UserLoginController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel model)
        {
            if (model.Username == "admin" && model.Password == "123456")
            {
                var token = _tokenService.GenerateToken(model.Username, model.Password);

                return Ok(new { Token = token }); 
            }
            else
            {
               
                return Ok("Kiểm tra lại tài khoản"); 
            }
        }
    }

}
