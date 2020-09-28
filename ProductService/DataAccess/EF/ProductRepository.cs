using Microsoft.EntityFrameworkCore;
using ProductService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace ProductService.DataAccess.EF
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDbContext productDbContext;

        public ProductRepository(ProductDbContext productDbContext)
        {
            this.productDbContext = productDbContext ?? throw new ArgumentException(nameof(productDbContext));
        }

        public async Task<Product> Add(Product product)
        {
            await productDbContext.Products.AddAsync(product);
            return product;
        }

        public async Task<List<Product>> FindAllActive()
        {
            return await productDbContext.Products
                .Include(c => c.Covers)
                .Include("Questions.Choices")
                .Where(x => x.Status == ProductStatus.Active)
                .ToListAsync();
        }

        public async Task<Product> FindById(Guid id)
        {
            return await productDbContext.Products.Include(c => c.Covers).Include("Questions.Choices")
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Product> FindOne(string productCode)
        {
            return await productDbContext.Products
                .Include(c => c.Covers)
                .Include("Questions.Choices")
                .FirstOrDefaultAsync(x => x.Code.Equals(productCode, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
