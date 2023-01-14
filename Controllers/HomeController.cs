using Microsoft.AspNetCore.Mvc;
using project.Data;
using project.Models;
using System.Diagnostics;

namespace project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            ProjectContext Context = ProjectContext.Instance;
            IProductRepository ProductRep = new ProductRepository(Context);
            return View(ProductRep.getAllProducts());
        }

        public IActionResult LoggedIn()
        {
            ProjectContext Context = ProjectContext.Instance;
            IProductRepository ProductRep = new ProductRepository(Context);
            return View(ProductRep.getAllProducts());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}