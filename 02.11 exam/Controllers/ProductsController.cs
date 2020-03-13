using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _02._11_exam.Data.Interfaces;
using _02._11_exam.Data.Models;
using _02._11_exam.Models;
using _02._11_exam.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace _02._11_exam.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProduct _products;
        private readonly ICategory _category;

        public ProductsController(IProduct products, ICategory category)
        {
            _products = products;
            _category = category;
        }

        //[Authorize(Roles="User")]
        [Route("Product/ListProducts")]
        //[Route("Cars/ListCars/{category}")] // таке саме як ім'я як і параметр
        public ViewResult ProductsList(string category)
        {
            var info = HttpContext.Session.GetString("UserInfo");
            if (info != null)
            {
                var result = JsonConvert.DeserializeObject<UserInfo>(info);
                var id = result.UserId;
            }

            IEnumerable<Product> products = null;
            string productCategory = "";
            if (string.IsNullOrEmpty(category))
            {
                products = _products.GetProducts.OrderBy(i=>i.ProductName);
            }
            else
            {
                products = _products.GetProducts
                    .Where(x => x.SubcategoryName.SubcategoryName.ToLower().Equals(category.ToLower()));

                //if (string.Equals("Benzin", category, StringComparison.OrdinalIgnoreCase))
                //{
                //    cars = _cars.GetCars.Where(x => x.Category.CategoryName.Equals("Benzin"))
                //        .OrderBy(i => i.Id);
                //}
                //else if (string.Equals("Diezel", category, StringComparison.OrdinalIgnoreCase))
                //{
                //    cars = _cars.GetCars.Where(x => x.Category.CategoryName.Equals("Diezel"))
                //        .OrderBy(i => i.Id);
                //}
                //else
                //{
                //    cars = _cars.GetCars.Where(x => x.Category.CategoryName.Equals("Electro"))
                //        .OrderBy(i => i.Id);
                //}



                productCategory = category;
            }

            var productObj = new ListProductsViewModel
            {
                GetProducts = products,
                ProductCategory = productCategory
            };

            return View(productObj);




        }
    }
}