using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            /*AuthService authService = new AuthService();
            if (authService.Login(email, password))
            {
                return RedirectToAction("welcome");
            }
            //if(email == "ruchitaamale@gmail.com" && password == "root") 
            //{
            //    return RedirectToAction("welcome");
            //}
            else
            {
                return View();
            }*/
            if(email=="adatkarpratiksha@gmail.com" && password == "abc")
            {
                this.HttpContext.Session["loggedinUser"] = email;
                return RedirectToAction("welcome");

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