﻿using _02._11_exam.Data.Interfaces;
using _02._11_exam.Data.Models;
using _02._11_exam.Models;
using _02._11_exam.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _02._11_exam.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategory _categories;
        private readonly ISubcategory _subcategories;

        public CategoriesController(ISubcategory subcategories, ICategory categories, ICategory category)
        {
            _subcategories = subcategories;
            _categories = categories;
        }

        //[Authorize(Roles="User")]
        [Route("Category/ListCategories")]
        //[Route("Cars/ListCars/{category}")] // таке саме як ім'я як і параметр
        public ViewResult CategoriesList()
        {
            var info = HttpContext.Session.GetString("UserInfo");
            if (info != null)
            {
                var result = JsonConvert.DeserializeObject<UserInfo>(info);
                var id = result.UserId;
            }

            IEnumerable<Category> categories = null;
            categories = _categories.GetCategories.OrderBy(i=>i.CategoryName);
            

            var categoryObj = new ListCategoriesViewModel
            {
                GetCategories = categories,
            };

            return View(categoryObj);




        }
        [Route("Category/ListSubcategories")]
        //[Route("Cars/ListCars/{category}")] // таке саме як ім'я як і параметр
        public ViewResult SubcategoriesList()
        {
            var info = HttpContext.Session.GetString("UserInfo");
            if (info != null)
            {
                var result = JsonConvert.DeserializeObject<UserInfo>(info);
                var id = result.UserId;
            }

            IEnumerable<Subcategory> subcategories = null;
            subcategories = _subcategories.GetSubcategories.OrderBy(i => i.SubcategoryName);


            var categoryObj = new ListSubcategoriesViewModel
            {
                GetSubcategories = subcategories,
            };

            return View(categoryObj);




        }
    }
}
