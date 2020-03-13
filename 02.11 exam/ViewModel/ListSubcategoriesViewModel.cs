using _02._11_exam.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _02._11_exam.ViewModel
{
    public class ListSubcategoriesViewModel
    {
        public IEnumerable<Subcategory> GetSubcategories { get; set; }
        public string MainCategory { get; set; }
    }
}
