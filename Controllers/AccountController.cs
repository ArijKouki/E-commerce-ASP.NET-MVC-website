using Microsoft.AspNetCore.Mvc;
using project.Data;
using project.Models;
using System.Diagnostics;

namespace project.Controllers
{
    public class AccountController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork(ProjectContext.Instance);
        
        public IActionResult All()
        {
            //userRepository.AddUser("Arij", "Kouki", "arijkouki17@gmail.com", "cookieee", "28/06/2001", "Tunis");
            List <User> l= unitOfWork.userRepository.GetAllUsers();
            ViewData["usersList"] = l;
            return View();
        }

        
            [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            User u= unitOfWork.userRepository.GetUserByLogin(email, password);
            if (u != null)
            {
                UserRepository.currentUser = u;
                return RedirectToAction("LoggedIn", "Home");
            }
            TempData["Error"] = "Wrong credentials. Please, try again!";
            return View();
        }

        public IActionResult LogOut()
        {
            UserRepository.currentUser = null;
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Profile()
        {
            if (UserRepository.currentUser != null)
            {
                ViewData["currentUser"] = UserRepository.currentUser;
            }
            else { TempData["Error"] = "You're not logged in!"; }
            return View();
        }

        [HttpGet]
        public IActionResult EditProfile()
        {
            if (UserRepository.currentUser != null)
            {
                ViewData["currentUser"] = UserRepository.currentUser;
            }
            else { TempData["Error"] = "You're not logged in!"; }
            return View();
        }
        [HttpPost]
        public IActionResult EditProfile(string first_name, string last_name, string email, string password, string birth_date, string address)
        {
            unitOfWork.userRepository.UpdateUser(first_name, last_name, email, password, birth_date, address);
            unitOfWork.Save();

            if (UserRepository.currentUser != null)
            {
                ViewData["currentUser"] = UserRepository.currentUser;
            }
            else { TempData["Error"] = "You're not logged in!"; }
            return View("Profile");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(string first_name, string last_name,string email,string password, string birth_date, string address)
        {

            unitOfWork.userRepository.AddUser(first_name, last_name, email, password, birth_date, address);
            unitOfWork.Save();
            return View("RegisterCompleted");
        }
    }
}
