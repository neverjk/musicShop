using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace _02._11_exam.Data.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Image { get; set; }
        public string Video { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        [ForeignKey("SubcategoryName")]
        public int SubcategoryId { get; set; }
        public virtual Subcategory SubcategoryName { get; set; }
        [ForeignKey("ManufacturerName")]
        public int ManufacturerId { get; set; }
        public virtual Category ManufacturerName { get; set; }
    }
}
