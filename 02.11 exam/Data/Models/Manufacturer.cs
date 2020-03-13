using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace _02._11_exam.Data.Models
{
    public class Manufacturer
    {
        public int Id { get; set; }
        public string ManufacturerName { get; set; }
        [ForeignKey("CountryName")]
        public int CountryId { get; set; }
        public virtual Country CountryName { get; set; }
    }
}
