using hf.Api.Responses;
using Microsoft.AspNetCore.Mvc;

namespace hf.Api.Controllers
{
    [Route("api/v{v:apiVersion}/[controller]")]
    [ApiController]
    public class InvoicesController : ControllerBase
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var invoices = new List<ListInvoiceResponse>() { 
                new ListInvoiceResponse(1,1, "Johan Potgieter", "Asus Laptop", "Asus Tuff A15", 1, 13900, "laptop.jpg"),
                new ListInvoiceResponse(1,2, "Nikki Heck", "Mouse", "Logitec Mouse", 2, 233.45m, "mouse.jpg"),
                new ListInvoiceResponse(1,1, "Johan Potgieter", "Keyboard", "Mecer Keyboard", 1, 329.00m, "keyboard.jpg"),
            }.AsReadOnly();
           
            var result = invoices.Where(p => p.ClientId == id).ToList();

            return Ok(result);
        }
    }
}