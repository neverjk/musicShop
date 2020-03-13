using _02._11_exam.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _02._11_exam.ViewModel
{
    public class ListCategoriesViewModel
    {
        public IEnumerable<Category> GetCategories { get; set; }
    }
}
