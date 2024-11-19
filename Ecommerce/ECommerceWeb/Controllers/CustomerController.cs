using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ECommerceEntities;

namespace EcommerceWeb.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            CustomerProfile theProfile = new CustomerProfile();
            theProfile.TheCustomer = new Customer
            {
                Id = 201,
                FirstName = "Pratiksha",
                LastName = "Adatkar",
                Contact = "7410542126",
                Email = "pratiksha.adatkar@gmail.com"
            };

            theProfile.OderHistory = new List<Order>();
            theProfile.OderHistory.Add(new Order { Id = 12, Status = "delivered", Created = DateTime.Now, Amount = 76000 });
            theProfile.OderHistory.Add(new Order { Id = 16, Status = "cancelled", Created = DateTime.Now, Amount = 34000 });

            ViewData["profile"] = theProfile;
            return View();
            /*List<Customer> customers = new List<Customer>();
            customers.Add(new Customer { Id = 1, FirstName = "Rutuja", LastName = "Patil", Email = "rsyadav@gmail.com", Contact = "8778964521" });
            customers.Add(new Customer { Id = 1, FirstName = "Sam", LastName = "Deshmukh", Email = "patil@gmail.com", Contact = "1234567890" });
            customers.Add(new Customer { Id = 1, FirstName = "Gauri", LastName = "Takilkar", Email = "sam@gmail.com", Contact = "9876543210" });
            customers.Add(new Customer { Id = 1, FirstName = "Jasmin", LastName = "Wedding Flower", Email = "tyafey@gmail.com", Contact = "4512789632" });
            customers.Add(new Customer { Id = 1, FirstName = "Lotus", LastName = "Wedding Flower", Email = "ftqyet@gmai.com", Contact = "7418529632" });

            return View(customers);*/
        }
    }
}
