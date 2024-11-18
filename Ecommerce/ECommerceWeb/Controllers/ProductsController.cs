

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
