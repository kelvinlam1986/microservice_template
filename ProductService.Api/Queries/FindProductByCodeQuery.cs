using MediatR;
using ProductService.Api.Queries.Dtos;

namespace ProductService.Api.Queries
{
    public class FindProductByCodeQuery : IRequest<ProductDTO>
    {
        public string ProductCode { get; set; }
    }
}
