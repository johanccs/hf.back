using AutoMapper;
using hf.Api.Requests;
using hf.Application.Commands.Products.CreateProduct;
using hf.Application.Queries.Products.GetProducts;
using hf.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace hf.Api.Controllers
{
    [Route("api/v{v:apiVersion}/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        #region readonly fields

        private readonly ISender _sender;
        private readonly IMapper _mapper;

        #endregion

        #region ctor

        public ProductsController(ISender sender, IMapper mapper)
        {
            _sender = sender;
            _mapper = mapper;
        }

        #endregion

        #region methods

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var query = new GetProductsQuery();
            
            var result = await _sender.Send(query);

            return Ok(result.Value);
        }

        [HttpPost]
        [Route("create-product")]
        public async Task<IActionResult> CreateProduct([FromBody]NewProductRequest request)
        {
            var productEntity = _mapper.Map<Product>(request);
            var productCommand = new CreateProductCommand(productEntity);

            var result = await _sender.Send(productCommand);

            return Ok(result);
        }

        #endregion
    }
}
