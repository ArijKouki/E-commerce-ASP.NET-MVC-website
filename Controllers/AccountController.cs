using Microsoft.AspNetCore.Mvc;
using project.Data;
using project.Models;
using System.Diagnostics;

namespace project.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult All()
        {
            UserRepository ur = new UserRepository();
            //ur.addUser("Arij", "Kouki", "arijkouki17@gmail.com", "cookieee", "28/06/2001", "Tunis");
            List <User> l= ur.all();
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
            UserRepository ur = new UserRepository();
            User u= ur.getUserByLogin(email, password);
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
            
            Debug.WriteLine(first_name);
            Debug.WriteLine(last_name);
            Debug.WriteLine(email);
            Debug.WriteLine(password);
            Debug.WriteLine(birth_date);
            Debug.WriteLine(address);

            UserRepository ur = new UserRepository();
            ur.updateUser(first_name, last_name, email, password, birth_date, address);

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
            UserRepository ur = new UserRepository();
            ur.addUser(first_name, last_name, email, password, birth_date, address);
            return View("RegisterCompleted");
        }
    }
}
