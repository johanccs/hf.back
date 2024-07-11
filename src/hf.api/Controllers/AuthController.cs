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
    }
}
