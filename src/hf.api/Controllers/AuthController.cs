using Asp.Versioning;
using AutoMapper;
using hf.Api.Requests;
using hf.Api.Responses;
using hf.Application.Commands.Users.CreateUser;
using hf.Application.Queries.Logins;
using hf.Application.Queries.Users.GetUsers;
using hf.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace hf.Api.Controllers
{
    [ApiVersion(1)]
    [Route("api/v{v:apiVersion}/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        #region fields

        private readonly ISender _sender;
        private readonly IMapper _mapper;

        #endregion

        #region Ctor
        public AuthController(ISender sender, IMapper mapper)
        {
            _sender = sender;
            _mapper = mapper;
        }

        #endregion

        [Route("Login")]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody]LoginRequest request)
        {
            var login = _mapper.Map<Login>(request);
            var query = new LoginQuery(login);

            var result = await _sender.Send(query);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            return Ok();
        }

        [Route("Register")]
        [HttpPost]
        public async Task<IActionResult> RegisterUser(
            [FromBody] NewUserRequest request, CancellationToken cancellationToken)
        {
            var domainUser = _mapper.Map<User>(request);
            var command = new CreateUserCommand(domainUser);

            var response = await _sender.Send(command,cancellationToken);

            return Created($"/auth/get/{response.Value}", response);
        }

        [Route("Reset-Password")]
        [HttpPost]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordRequest request)
        {
            var response = new { Id = 1 };
            return Created($"/auth/get/{response.Id}", response);
        }

        [Route("get-users")]
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var query = new GetUsersQuery();

            var result = await _sender.Send(query);

            return Ok(result.Value);
        }
    }
}
