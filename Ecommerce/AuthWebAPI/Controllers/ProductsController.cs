

using System;

using System.Collections.Generic;

using System.Linq;

using System.Web;

using System.Web.Mvc;

using ECommerceEntities;

using Specification;

using ECommerceServices;

namespace ECommerceWeb.Controllers

{

    public class ProductsController : Controller

    {

        // GET: Products

        public ActionResult Index()

        {




            IProductService p = new ProductService();

            ProductService svc = (ProductService)p;

            svc.Seeding();

            List<Product> products = p.GetAll();

            return View(products);


            /* List<Product> products = new List<Product>();

             products.Add(new Product { Id = 1, Title = "Jasmine", Description = "Fragnance", Unitprice = 32, Quantity = 30, Image = "/images/Jasmine.jpg" });

             products.Add(new Product { Id = 2, Title = "Rose", Description = "Love", Unitprice = 12, Quantity = 80, Image = "/images/Rose.jpg" });

             products.Add(new Product { Id = 4, Title = "Lotus", Description = "Worship", Unitprice = 40, Quantity = 70, Image = "/images/Lotus.jpg" });

             products.Add(new Product { Id = 1, Title = "Lily", Description = "Beautiful", Unitprice = 20, Quantity = 100, Image = "/images/Lily.jpg" });

             return View(products);

             //return View();*/

        }

        public ActionResult Update()

        {

            return View();

        }

        public ActionResult Delete()

        {

            return View();

        }

        public ActionResult Insert()

        {

            return View();

        }

        public ActionResult Details(int id)

        {

            IProductService productService = new ProductService();

            Product product = productService.GetById(id);

            return View(product);

            // return View();

        }

    }

}
