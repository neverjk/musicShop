using _02._11_exam.Data.EFContext;
using _02._11_exam.Data.Interfaces;
using _02._11_exam.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _02._11_exam.Data.Repository
{
    public class CategoryRepository : ICategory
    {
        private readonly EFDbContext _context;

        public CategoryRepository(EFDbContext dbContext)
        {
            _context = dbContext;
        }

        public IEnumerable<Category> GetCategories => _context.Categories;
    }
}
