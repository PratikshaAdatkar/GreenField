using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ECommerceEntities;
using Specification;
using ECommerceServices;
using Services;

namespace ECommerceWeb.Controllers
{
    public class ShoppingCartController : Controller
    {
        // GET: ShpooingCart
        public ActionResult Index()
        {

            Cart myCart = (Cart)this.HttpContext.Session["cart"];
            ICartService cartService = new CartService(myCart);
            List<Item> items = cartService.GetAll();
            ViewData["items"] = items;
            return View();
        }
        [HttpPost]

        public ActionResult AddToCart(Item i)
        {
            Cart myCart = (Cart)this.HttpContext.Session["cart"];
            ICartService cartService = new CartService(myCart);
            cartService.AddToCart(i);
            return RedirectToAction("Index", "Product");
        }
        public ActionResult AddToCart(int id)
        {
            Item item = new Item();
            item.ProductId = id;
            item.Quantity = 0;
            ViewData["item"] = item;
            return View(item);
        }

        public ActionResult RemoveFromCart(int id)
        {
            Cart myCart = (Cart)this.HttpContext.Session["cart"];
            ICartService cartService = new CartService(myCart);
            cartService.RemoveFromCart(id);
            return RedirectToAction("index", "product");
        }
        public ActionResult Clear()
        {
            Cart myCart = (Cart)this.HttpContext.Session["cart"];
            ICartService cartService = new CartService(myCart);
            cartService.Empty();
            return RedirectToAction("Index", "Product");
        }

    }
}