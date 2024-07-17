using hf.api.Responses;
using Microsoft.AspNetCore.Mvc;

namespace hf.api.Controllers
{
    [Route("api/v{v:apiVersion}/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var invoices = new List<ListProductResponse>() {
                new ListProductResponse(1, "Asus Laptop", "Asus Tuff A15", 13900, 1,  "laptop.jpg"),
                new ListProductResponse(1, "Mouse", "Logitec Mouse", 233.45m, 2, "mouse.jpg"),
                new ListProductResponse(1, "Keyboard", "Mecer Keyboard", 329.00m,1, "keyboard.jpg"),
            }.AsReadOnly();

            return Ok(invoices);
        }
    }
}
