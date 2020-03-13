﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _02._11_exam.Data.Models.Helpers
{
    public class Filter<TEntity> where TEntity : class
    {
        public string Name { get; set; }

        public Func<TEntity, bool> Expression { get; set; }
    }
}
