using Models.Framework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Admin
{
    public class CategoryModel
    {
        private LipstickDbContext _context = null;
        public CategoryModel()
        {
            _context = new LipstickDbContext();
        }
        public async Task<List<Category>> Index()
        {

            var list = await _context.Categories.ToListAsync();
            return list;
        }
        // GET: Categories/Details/5
        public async Task<Category> Details(int id)
        {
            Category category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                category = new Category
                {
                    Id = 0,
                    Alias = "",
                    Name = " ",
                    ParentID = 0,
                    Status = false,
                };
            }
            return category;
        }
        //[HttpPost]
        public async Task<int> Create(Category request)
        {
            var category = new Category
            {
                Id=request.Id,
                Name=request.Name,
                Alias=request.Alias,
                ParentID=request.ParentID,
                Createddate=request.Createddate,
                Status=request.Status,
            };
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return category.Id;
        }
        //[HttpPost]
        public async Task<int> Update(Category request)
        {
            var category = await _context.Categories.FindAsync(request.Id);
            category.Id = request.Id;
            category.Name = request.Name;
            category.Alias = request.Alias;
            category.ParentID = request.ParentID;
            category.Createddate = request.Createddate;
            category.Status = request.Status;         
            await _context.SaveChangesAsync();
            return 1;
        }

        // GET: Categories/Edit/5
        public async Task<Category> GetEdit(int? Id )
        {           
            Category category = await _context.Categories.FindAsync(Id);
            if (category == null)
            {
                category = new Category
                {
                    Id = 0,
                };
                return category;
            }
            return category;
        }
    }
}
