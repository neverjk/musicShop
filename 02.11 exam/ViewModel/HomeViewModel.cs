﻿using _02._11_exam.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _02._11_exam.ViewModel
{
    public class HomeViewModel
    {
        public IEnumerable<Product> GetProducts { get; set; }

    }
}
