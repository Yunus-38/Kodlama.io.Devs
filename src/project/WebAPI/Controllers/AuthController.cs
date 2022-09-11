using Application.Features.Users.Commands.LoginUser;
using Application.Features.Users.Commands.RegisterUser;
using Application.Features.Users.Dtos;
using Core.Security.Dtos;
using Core.Security.JWT;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserForRegisterDto userForRegisterDto)
        {
            RegisterUserCommand registerUserCommand = new() { UserForRegisterDto = userForRegisterDto };
            AccessToken accessToken = await Mediator.Send(registerUserCommand);

            return Ok(accessToken);

        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserForLoginDto userForLoginDto)
        {
            LoginUserCommand loginUserCommand = new() { UserForLoginDto = userForLoginDto };
            AccessToken accessToken = await Mediator.Send(loginUserCommand);

            return Ok(accessToken);


        }
    }
}
