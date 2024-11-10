using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Catalog;


namespace ECommerceWeb.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {
           /* IProductService productService = new ProductService();
            List<Product> products = svc.GetAll();
            return View(products); }*/

            List<Product> products = new List<Product>();
            products.Add(new Product { Id = 1, Name = "Jasmine", Description = "Fragnance", UnitPrice = 32, Quantity = 30, image = "/images/Jasmine.jpg" });
            products.Add(new Product { Id = 2, Name = "Rose", Description = "Love", UnitPrice = 12, Quantity = 80, image = "/images/rose.jpg" });
            products.Add(new Product { Id = 4, Name = "Lotus", Description = "Worship", UnitPrice = 40, Quantity = 70, image = "/images/Lotus.jpg" });
            products.Add(new Product { Id = 1, Name = "Lily", Description = "Beautiful", UnitPrice = 20, Quantity = 100, image = "/images/Lily.jpg" });

            return View(products);
        }
        public ActionResult Details()
        {
            return View();
        }
        public ActionResult Insert() {
            return View();
        }
        public ActionResult Update()
        {
            return View();
        }
        public ActionResult Delete()
        {
            return View();
        }
    }
}