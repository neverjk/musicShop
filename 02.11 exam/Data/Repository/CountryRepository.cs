using _02._11_exam.Data.EFContext;
using _02._11_exam.Data.Interfaces;
using _02._11_exam.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _02._11_exam.Data.Repository
{
    public class CountryRepository : ICountry
    {
        private readonly EFDbContext _context;

        public CountryRepository(EFDbContext dbContext)
        {
            _context = dbContext;
        }

        public IEnumerable<Country> GetCountries => _context.Countries;
    }
}
