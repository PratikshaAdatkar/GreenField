using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ECommerceEntities;

namespace ECommerceWeb.Controllers

{

    public class ShoppingCartController : Controller

    {

        // GET: ShoppingCart

        public ActionResult Index()

        {

            Cart mycart = (Cart)this.HttpContext.Session["cart"];

            ViewData["cart"] = mycart;

            return View();

        }

        public ActionResult AddtoCart()

        {

            return View();

        }

        [HttpPost]

        public ActionResult AddtoCart(Item theItem)

        {

            Cart mycart = (Cart)this.HttpContext.Session["cart"];

            mycart.items.Add(theItem);

            return RedirectToAction("Index", "Product");

        }

        public ActionResult RemovefromCart(int id)

        {

            Cart mycart = (Cart)this.HttpContext.Session["cart"];

            mycart.items.RemoveAll((item) => (item.ProductId == id));

            return View();

        }

    }

}
