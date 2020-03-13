using _02._11_exam.Data.Interfaces;
using _02._11_exam.Models;
using _02._11_exam.Services;
using _02._11_exam.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading.Tasks;

namespace _02._11_exam.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProduct _products;
        private readonly ICategory _category;

        public HomeController(IProduct products, ICategory category)
        {
            _products = products;
            _category = category;
        }

        [HttpGet]
        public IActionResult AddFilesForm()
        {
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> AddFilesForm(IFormFile uploadedFile)
        {
            FileService service = new FileService();
            await service.AddFile(uploadedFile);
            return RedirectToAction("Login", "Account");
        }

        public ViewResult Index()
        {
            var products = new HomeViewModel() { GetProducts = _products.GetProducts };

            return View(products);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
