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
    public class ManufacturerRepository : IManufacturer
    {
        private readonly EFDbContext _context;

        public ManufacturerRepository(EFDbContext dbContext)
        {
            _context = dbContext;
        }

        public IEnumerable<Manufacturer> GetManufacturers => _context.Manufacturers.Include(x=>x.CountryName);

    }
}
