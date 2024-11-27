using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ECommerceEntities;
using Specification;
using ECommerceServices;
using Services;

namespace AuthWebAPI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            string result = "Invalid User";
            if (email == "pratikshaadatkar@gmail.com" && password == "123")
            {
                result = "Valid User";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetUser()
        {
            var result = new
            {
                FirstName = "Pratiksha",
                LastName = "Adatkar"
            };
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Storage()
        {
            return View();
        }
        public ActionResult JqueryDemo()
        {
            return View();
        }
        public ActionResult ClientLogin()
        {
            return View();
        }

        public ActionResult ClientRegister()
        {
            return View();
        }
        public ActionResult Sliders()
        {
            return View();
        }
        public ActionResult Catalog()
        {
            return View();
        }
    }
}