using _02._11_exam.Data.EFContext;
using _02._11_exam.Data.Interfaces;
using _02._11_exam.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _02._11_exam.Data.Repository
{


    public class ProductRepository : IProduct
    {
        private readonly EFDbContext _context;

        public ProductRepository(EFDbContext dbContext)
        {
            _context = dbContext;
        }

        public IEnumerable<Product> GetProducts => _context.Products.Include(x => x.SubcategoryName).Include(x => x.ManufacturerName);



        //public IEnumerable<Product> GetProductsAvailable => (_context.Products.Include(x => x.CategoryName).Include(x => x.ManufacturerName)).Where(x=>x.
    }
}
