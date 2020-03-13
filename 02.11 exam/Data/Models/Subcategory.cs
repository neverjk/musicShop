using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _02._11_exam.Data.Models
{
    public class Subcategory
    {
        public int Id { get; set; }
        public string SubcategoryName { get; set; }

        public int? CategoryID { get; set; }
        public virtual Category Category { get; set; }
    }
}
