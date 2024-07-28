using Asp.Versioning;
using AutoMapper;
using hf.Api.Helpers;
using hf.Api.Requests;
using hf.Application.Commands.Users.CreateUser;
using hf.Application.Queries.Logins;
using hf.Application.Queries.Users.GetUsers;
using hf.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


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
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            if (request is null)
                return BadRequest("Invalid client request");

            var login = _mapper.Map<Login>(request);
            var query = new LoginQuery(login);

            var result = await _sender.Send(query);

            if (result.IsSuccess)
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Tokens.JWTBearerToken));
                var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var tokenOptions = new JwtSecurityToken(
                        issuer: "https://localhost:5001",
                        audience: "https://localhost:5001",
                        claims: new List<Claim>(),
                        expires: DateTime.Now.AddMinutes(5),
                        signingCredentials: signingCredentials);

                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

                result.Token = tokenString;
                return Ok(result);
            }

            return NotFound("Invalid username of password");
        }

        [Route("Register")]
        [HttpPost]
        public async Task<IActionResult> RegisterUser(
            [FromBody] NewUserRequest request, CancellationToken cancellationToken)
        {
            if (request is null)
                return BadRequest("Invalid client request");

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
