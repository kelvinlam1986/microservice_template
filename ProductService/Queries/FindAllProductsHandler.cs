using MediatR;
using ProductService.Api.Queries;
using ProductService.Api.Queries.Dtos;
using ProductService.Domain;
using ProductService.Queries.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ProductService.Queries
{
    public class FindAllProductsHandler : IRequestHandler<FindAllProductQuery, IEnumerable<ProductDTO>>
    {
        private readonly IProductRepository productRepository;

        public FindAllProductsHandler(IProductRepository productRepository)
        {
            this.productRepository = productRepository ?? throw new ArgumentException(nameof(productRepository));
        }

        public async Task<IEnumerable<ProductDTO>> Handle(FindAllProductQuery request, CancellationToken cancellationToken)
        {
            var results = await this.productRepository.FindAllActive();
            return results.Select(p => new ProductDTO
            {
                Code = p.Code,
                Name = p.Name,
                Description = p.Description,
                Image = p.Image,
                MaxNumberOfInsured = p.MaxNumberOfInsured,
                Icon = p.ProductIcon,
                Questions = p.Questions != null ? ProductMapper.ToQuestionDtoList(p.Questions) : null,
                Covers = p.Covers != null ? ProductMapper.ToCoverDtoList(p.Covers) : null
            }).ToList();
        }
    }
}
