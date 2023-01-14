using Microsoft.AspNetCore.Mvc;
using project.Data;
using project.Models;


namespace project.Controllers
{
    public class ProductController : Controller
    {
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
    }
}
