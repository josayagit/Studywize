using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudyWizeWeb.Models;


namespace StudyWizeWeb.Controllers
{
    public class AccountController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(StudentAccount account)
        {
            if (ModelState.IsValid)
            {
                using(OurDBContext db = new OurDBContext())
                {
                    db.userAccount.Add(account);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = account.FirstName + " " + account.LastName + " successfully registered";
                
            }
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        
        public IActionResult Login(StudentAccount user)
        {
            using(OurDBContext db = new OurDBContext())
            {
                var usr = db.userAccount.Single(u => u.Username == user.Username && u.Password == user.Password);
                if (usr != null)
                {
                    HttpContext.Current.Session["UserID"] = usr.UserID.ToString();
                    HttpContext.Current.session["UserID"] = usr.UserID.ToString();
                    Session["Username"] = usr.Username.ToString();
                    return RedirectToAction("LoggedIn");
                }
                else
                {
                    ModelState.AddModelError("", "Username or Password is wrong.");
                }
                return View();
            }
        }

        public IActionResult LoggedIn()
        {
            if (Session["UserId"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
    }
}
