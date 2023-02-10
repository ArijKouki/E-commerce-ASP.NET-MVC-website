using Microsoft.AspNetCore.Mvc;
using project.Models;
using project.Data;
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Diagnostics;




namespace project.Controllers
{
    public class OrdersController : Controller
    {

        private IUnitOfWork unitOfWork;
        public OrdersController()
        {
            this.unitOfWork = new UnitOfWork(ProjectContext.Instance);
        }

        public IActionResult Index()
        {
            User u = UserRepository.currentUser;
            if (u == null) { TempData["Error"] = "You need to be logged in to view or manage your shopping cart."; }
            else
            {
                var CartItems = unitOfWork.CartItems.GetAllItemsInCartByUser(u.User_Id);
                int n = 0;
                if (CartItems!=null) { n = CartItems.Count(); }
                ViewData["n"] = n;
                ViewData["CartItems"] = CartItems;
            }
            return View();
        }

        public IActionResult Add(int Product_Id, int Quantity=1)
        {
            /*Debug.WriteLine("pid " + Product_Id);
            Debug.WriteLine("Q " + Quantity);*/
            Product p = unitOfWork.Products.getProductById(Product_Id);
            //Debug.WriteLine("ps " + p.singer);
            User u = UserRepository.currentUser;
            //Debug.WriteLine(u.last_name);
            if (u == null) { return RedirectToAction("Index"); }
            
                if (p == null) { TempData["ProductError"] = "Product not found."; }
                else
                {
                    float itemSum = p.price * Quantity;
                    CartItem item = new CartItem(u.User_Id, Product_Id, p.name, p.img, Quantity, itemSum);
                    Debug.WriteLine("id" + item.Item_Id);
                    unitOfWork.CartItems.Add(item);
                    unitOfWork.Save();
                }

            
            return RedirectToAction("Index");
        }
        public IActionResult Remove(int Item_Id)
        {
            Debug.WriteLine(Item_Id);
            User u = UserRepository.currentUser;
            Debug.WriteLine(u.last_name);
            if (u != null)
            {

                unitOfWork.CartItems.RemoveItem(Item_Id);
                unitOfWork.Save();

            }
            return RedirectToAction("Index");
        }

        public IActionResult Order()
        {
            User u = UserRepository.currentUser;
            if (u == null) { return RedirectToAction("Index"); }
            List<CartItem> cartItems = (List<CartItem>)unitOfWork.CartItems.GetAllItemsInCartByUser(u.User_Id);
            if(cartItems==null ||  cartItems.Count==0) {  return RedirectToAction("Index"); }
            float Total = 0;
            foreach (var item in cartItems)
            {
                Total += item.Sum;
                Product p= unitOfWork.Products.getProductById(item.Product_Id);
                p.nb_exemplaires -= item.Quantity;
                unitOfWork.Products.UpdateProduct(p);

            }
            Order order = new Order(u.User_Id, Total);
            unitOfWork.Orders.Add(order);

            unitOfWork.Save();

            foreach (var item in cartItems)
            {
                item.Order_Id = order.Order_Id;
                unitOfWork.CartItems.UpdateItem(item);
            }

            unitOfWork.Save();
            ViewData["order"] = order;
            return View();
        }
    }
}