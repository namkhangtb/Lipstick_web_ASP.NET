using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Admin
{
    public class ProductModel
    {
        private LipstickDbContext _context = null;
        public ProductModel()
        {
            _context = new LipstickDbContext();
        }
        //[HttpPost]
        public async Task<int> Create(Product request)
        {        
            var product = new Product
            {
                Id = request.Id,
                Name = request.Name,
                Alias = request.Alias,
                CategoryId = request.CategoryId,
                Images = request.Images,
                Createdate = request.Createdate,
                Price=request.Price,
                Detail=request.Detail,
                Status = request.Status,
            };
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product.Id;
        }
    }
}
