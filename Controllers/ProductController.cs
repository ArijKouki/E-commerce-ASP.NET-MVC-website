using Microsoft.AspNetCore.Mvc;
using project.Data;
using project.Models;
using System.Diagnostics;



namespace project.Controllers
{
    public class ProductController : Controller
    {
        private IUnitOfWork unitOfWork;
        public ProductController()
        {
            this.unitOfWork = new UnitOfWork(ProjectContext.Instance);
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Singles()
        {
            ProjectContext Context = ProjectContext.Instance;
            IProductRepository ProductRep = new ProductRepository(Context);
            return View(ProductRep.GetProductByType("single"));
        }
        public IActionResult Albums()
        {
            ProjectContext Context = ProjectContext.Instance;
            IProductRepository ProductRep = new ProductRepository(Context);
            return View(ProductRep.GetProductByType("album"));
            
        }
        public ActionResult Details(int Product_Id) {

            ProjectContext Context = ProjectContext.Instance;
            IProductRepository ProductRep = new ProductRepository(Context);
            Product p= ProductRep.getProductById(Product_Id);
            if(p==null) { TempData["Error"] = "Product not found"; }
            ViewData["Product"] = p;
            return View(); 
        }

        public ActionResult ProductByGenre(string genre)
        {
            ProjectContext Context = ProjectContext.Instance;
            IProductRepository ProductRep = new ProductRepository(Context);
            return View(ProductRep.GetProductByGenre(genre));
        }
        [HttpGet]
        public IActionResult Search(string searchTerm)
        {
            Debug.WriteLine(searchTerm);
            List<Product> Products = new List<Product>();
            if (!string.IsNullOrEmpty(searchTerm))
            {
                Products =(List < Product >) unitOfWork.Products.SearchByNameSinger(searchTerm);
                Debug.WriteLine(Products);
            }
            ViewData["products"]=Products;
            return View();
        }
    }
}
