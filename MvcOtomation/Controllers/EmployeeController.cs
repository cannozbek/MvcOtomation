using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOtomation.Models.Classes;

namespace MvcOtomation.Controllers
{
    public class EmployeeController : Controller
    {
        Context context = new Context();
        // GET: Employee
        public ActionResult Index()
        {
            var employees = context.Employees.ToList();
            return View(employees);
        }

        [HttpGet]
        public ActionResult AddEmployee()
        {
            List<SelectListItem> ListDepartment = (from x in context.Departments.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.Name,
                                                     Value = x.Id.ToString()
                                                 }).ToList();

            
            ViewBag.ListDepartmentBag = ListDepartment;
            return View();
        }

        [HttpPost]
        public ActionResult AddEmployee(Employee employee)
        {
            context.Employees.Add(employee);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult FetchEmployee(int id)
        {
            var Employees = context.Employees.Find(id);
            List<SelectListItem> ListDepartment = (from x in context.Departments.ToList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.Name,
                                                       Value = x.Id.ToString()
                                                   }).ToList();


            ViewBag.ListDepartmentBag = ListDepartment;
            return View("FetchEmployee", Employees);
        }

        public ActionResult UpdateEmployee(Employee EmployeeInput)
        {
            var EmployeeUpdate = context.Employees.Find(EmployeeInput.Id);
            EmployeeUpdate.Name = EmployeeInput.Name;
            EmployeeUpdate.Surname = EmployeeInput.Surname;
            EmployeeUpdate.Photo = EmployeeInput.Photo;
            EmployeeUpdate.DepartmentId = EmployeeInput.DepartmentId;

            context.SaveChanges();
            return RedirectToAction("Index");

        }


    }
}