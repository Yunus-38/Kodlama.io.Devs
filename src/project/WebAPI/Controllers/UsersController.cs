using Application.Features.UserGithubs.Commands.CreateUserGithub;
using Application.Features.UserGithubs.Commands.DeleteUserGithub;
using Application.Features.UserGithubs.Commands.UpdateUserGithub;
using Application.Features.UserGithubs.Dtos;
using Application.Features.Users.Models;
using Application.Features.Users.Queries.GetListUser;
using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : BaseController
    {
        [HttpPost("addGithub")]
        public async Task<IActionResult> Add([FromBody] CreateUserGithubCommand createUserGithubCommand)
        {
            CreatedUserGithubDto result = await Mediator.Send(createUserGithubCommand);
            return Ok(result);
        }

        [HttpPost("updateGithub")]
        public async Task<IActionResult> Update([FromBody] UpdateUserGithubCommand updateUserGithubCommand)
        {
            UpdatedUserGithubDto result = await Mediator.Send(updateUserGithubCommand);
            return Ok(result);
        }

        [HttpPost("deleteGithub")]
        public async Task<IActionResult> Delete([FromBody] DeleteUserGithubCommand deleteUserGithubCommand)
        {
            DeletedUserGithubDto result = await Mediator.Send(deleteUserGithubCommand);
            return Ok(result);
        }

        [HttpGet("getList")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListUserQuery request = new() { PageRequest = pageRequest };
            UserListModel result = await Mediator.Send(request);
            return Ok(result);
        }
    }
}
