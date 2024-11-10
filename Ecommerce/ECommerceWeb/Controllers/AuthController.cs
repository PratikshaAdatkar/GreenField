using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerceWeb.Controllers
{
    public class AuthController : Controller
    {
        // GET: Auth
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ForgetPassword()
        {
            return View();
        }
        public ActionResult ResetPassword()
        {
            return View();
        }
    }
}