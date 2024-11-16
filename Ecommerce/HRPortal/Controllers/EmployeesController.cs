using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRPortal.Models;
using HRPortal.Services;

namespace HRPortal.Controllers
{
    public class EmployeesController : Controller
    {
        // GET: Employees
        public ActionResult Index()
        {

            EmployeeService svc = new EmployeeService();
            //svc.Seeding();
            List<Employee> employees = svc.GetAllEmployees();
            ViewData["list"] = employees;
            return View();
        }

        public ActionResult Details(int id)
        {
            EmployeeService svc = new EmployeeService();
            //lambda expression (arrow function)
            Employee employee = svc.GetEmployee(id);
            return View(employee);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            string firstname = collection["firstname"];
            string lastname = collection["lastname"];
            string emaill = collection["email"];
            string contactnumber = collection["contactnumber"];
            return View();
        }
        public ActionResult Delete(int id)
        {
            EmployeeService service = new EmployeeService();
            service.Delete(id);
            return RedirectToAction("Index");
        }
        public ActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Insert(Employee emp)
        {
            EmployeeService svc = new EmployeeService();
            svc.Register(emp);
            return RedirectToAction("index");
        }

        public ActionResult Edit(int id)
        {
            Employee employee = new Employee();
            EmployeeService svc = new EmployeeService();
            employee = svc.GetEmployee(id);
           
            return View(employee);
        }
        [HttpPost]
        public ActionResult Edit(Employee emp)
        {
            EmployeeService svc = new EmployeeService();
            svc.Update(emp);
            return RedirectToAction("index");
        }
    }
}