using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HDFCBankApp.Services;
namespace HDFCBankApp.Controllers
{
    public class AuthController : Controller
    {
        // GET: Auth
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            this.HttpContext.Session["loggedinUser"] =email;
            AuthService authService = new AuthService();
            if (authService.Login(email, password))
            {
                return RedirectToAction("welcome");
            }
            //if(email == "ruchitaamale@gmail.com" && password == "root") 
            //{
            //    return RedirectToAction("welcome");
            //}
            /*
            else
            {
                return View();
            }
            if(email=="adatkarpratiksha@gmail.com" && password == "abc")
            {
                this.HttpContext.Session["loggedinUser"] = email;
                return RedirectToAction("welcome");

            }
            */
            else
            {
                return View();
            }
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(string firstname, string lastname, string email, long contactnumber, string location)
        {
            IAuthService authService = new AuthService();
            this.HttpContext.Session["loggedinUser"] = email;

            if (authService.Register(firstname, lastname, email, contactnumber, location))
            {
                return RedirectToAction("Welcome");
            }
            else
            {
                return View();
            }

        }
        public ActionResult Welcome()
        {
            string email = this.HttpContext.Session["loggedinUser"] as string;
            ViewBag.Email = email;
            return View();
        }

    }
}