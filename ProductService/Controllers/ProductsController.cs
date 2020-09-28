using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductService.Api.Commands;
using ProductService.Api.Queries;

namespace ProductService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator mediator;

        public ProductsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var result = await mediator.Send(new FindAllProductQuery());
            return new JsonResult(result);
        }

        // POST api/products
        [HttpPost]
        public async Task<ActionResult> PostDraft([FromBody] CreateProductDraftCommand request)
        {
            var result = await mediator.Send(request);
            return new JsonResult(result);
        }
    }
}
