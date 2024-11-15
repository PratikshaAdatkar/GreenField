using System;

using System.Collections.Generic;

using System.Linq;

using System.Web;

using System.Web.Mvc;

using HRPortal.Models;

namespace HRPortal.Controllers

{

    public class EmployeesController : Controller

    {

        // GET: Employees

        public ActionResult Index()

        {

            return View();

        }

        public ActionResult Details(int id)

        {

            return View();

        }

        public ActionResult Create()

        {

            return View();

        }

        [HttpPost]

        public ActionResult Create(FormCollection collection)

        {

            string firstName = collection["firstname"] as string;

            string lastName = collection["lastname"] as string;

            string email = collection["email"] as string;

            string contactNumber = collection["contactnumber"] as string;

            return View();

        }

        public ActionResult Insert()

        {

            return View();

        }

        [HttpPost]

        public ActionResult Insert(Employee emp)

        {

            return View();

        }

        public ActionResult Edit(int id)

        {

            Employee employee = new Employee();

            employee.Id = 1;

            employee.Name = "Pratiksha Adatkar";

            employee.IsConfirmed = true;

            employee.DailyAllowance = 100;

            employee.WorkingDays = 100;

            employee.JoinDate = DateTime.Now;

            employee.BasicSalary = 15000;

            return View(employee);

        }

        [HttpPost]


        public ActionResult Edit(Employee emp)

        {

            return View();

        }

    }

}
