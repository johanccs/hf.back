using AutoMapper;
using hf.Api.MapperProfile;
using hf.Api.Requests;
using hf.Application.Commands.Invoices.CreateInvoice;
using hf.Application.Queries.Invoices.GetInvoices;
using hf.Domain.Abstractions;
using hf.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace hf.Api.Controllers
{
    [Route("api/v{v:apiVersion}/[controller]")]
    [ApiController]
    public class InvoicesController : ControllerBase
    {
        #region readonly fields

        private readonly ISender _sender;
        private readonly IMapper _mapper;

        #endregion

        #region ctor

        public InvoicesController(ISender sender, IMapper mapper)
        {
            _sender = sender;
            _mapper = mapper;
        }

        #endregion

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> Get(string id)
        {
            var query = new GetInvoicesQuery(id);

            var invoices = await _sender.Send(query);

            var result = MappingProfileV2.MapTo(invoices.Value);

            return Ok(result);
        }

        [HttpPost]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Result))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("create-invoice")]
        public async Task<IActionResult> CreateInvoice([FromBody] InvoiceHeaderRequest request)
        {
            var invoice = _mapper.Map<InvoiceHeader>(request);

            var command = new CreateInvoiceCommand(invoice);

            var result = await _sender.Send(command);

            return Ok(result);
        }
    }
}