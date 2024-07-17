using Asp.Versioning;
using hf.api.Requests;
using hf.api.Responses;
using Microsoft.AspNetCore.Mvc;

namespace hf.api.Controllers
{
    [ApiVersion(1)]
    [Route("api/v{v:apiVersion}/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Login([FromBody]LoginRequest  request)
        {

            return Ok(new LoginResponse(true));
        }

        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            return Ok();
        }

        [Route("Create")]
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] NewUserRequest request)
        {
            var response = new {Id=1};
            return Created($"/auth/get/{response.Id}", response);
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
            var list = new List<CreatedUserResponse>()
            {
                new CreatedUserResponse(1, "Johan", "Potgieter", "johan.ccs@gmail.com", "username", true, DateTime.Now.ToString("yyyy/MM/dd"),false),
                new CreatedUserResponse(1, "Nikki", "Heck", "nikki@gmail.com","username", false, DateTime.Now.ToString("yyyy/MM/dd"),true),
                new CreatedUserResponse(1, "John", "Smith", "john@gmail.com", "username", false, DateTime.Now.ToString("yyyy/MM/dd"),true),
                new CreatedUserResponse(1, "Malcolm", "Marx", "malcolm@gmail.com", "username", false, DateTime.Now.ToString("yyyy/MM/dd"),false),
            };

            return Ok(list);
        }
    }
}
