using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HDFCBankApp.Models;

namespace HDFCBankApp.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        private List<Customer> list = new List<Customer>();
        public CustomersController() {
            list.Add(new Customer { Id = 1, Name = "Microsoft", Email = "bill.gates@as.com", Location="Mumbai",ContactNumber = "7410542126" });
            list.Add(new Customer { Id = 2, Name = "IBM", Email = "jhon.gateways@as.com",Location="USA", ContactNumber = "9075652126" });
            list.Add(new Customer { Id = 3, Name = "Infosys", Email = "bill.waters@as.com",Location="Europe" ,ContactNumber = "548763212126" });
        }
        public ActionResult Index()
        { 
            ViewData["list"]=list;  
            return View();
      
        }
        public ActionResult Details(int id)
        {//lamda expression (arrow function)
            Customer customer = list.Find(cust => cust.Id == id);    
            return View(customer);
        }
        
    }
}