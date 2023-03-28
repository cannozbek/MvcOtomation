using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOtomation.Models.Classes;


namespace MvcOtomation.Controllers
{
    public class DepartmentController : Controller
    {
        Context context = new Context();

        // GET: Department
        public ActionResult Index()
        {
            var deparments = context.Departments.Where(x => x.State == true).ToList();
            return View(deparments);
        }

        [HttpGet]
        public ActionResult AddDeparment()
        {
            List<SelectListItem> ListState = new List<SelectListItem>();
            ListState.Add(new SelectListItem { Text = true.ToString(), Value = true.ToString() });
            ListState.Add(new SelectListItem { Text = false.ToString(), Value = false.ToString() });


            ViewBag.ListStateBag = ListState;
            return View();
        }

        [HttpPost]
        public ActionResult AddDeparment(Department department)
        {
            context.Departments.Add(department);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteDepartment(int Id)
        {
            var DeleteDepartment = context.Departments.Find(Id);
            DeleteDepartment.State = false;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult FetchDepartment(int id)
        {
            var deparments = context.Departments.Find(id);
            List<SelectListItem> ListState = new List<SelectListItem>();
            ListState.Add(new SelectListItem { Text = true.ToString(), Value = true.ToString() });
            ListState.Add(new SelectListItem { Text = false.ToString(), Value = false.ToString() });


            ViewBag.ListStateBag = ListState;

            return View("FetchDepartment", deparments);
        }

        public ActionResult UpdateDepartment(Department departmentInput)
        {
            var deparmentUpdate = context.Departments.Find(departmentInput.Id);
            deparmentUpdate.Name = departmentInput.Name;

            deparmentUpdate.State = departmentInput.State;


            context.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult DetailsDepartment(int id)
        {
            var employees = context.Employees.Where(x => x.DepartmentId == id).ToList();
            var departmentName = context.Departments.Where(x => x.Id == id).Select(y => y.Name).FirstOrDefault();
            ViewBag.departmentNameBag = departmentName;
            return View(employees);

        }
        public ActionResult DeparmentEmployeeSales(int id)
        {
            var sales = context.SalesTransactions.Where(x => x.EmployeeId == id).ToList();
            var employeeName = context.Employees.Where(x => x.Id == id).Select(y => y.Name + " " + y.Surname).FirstOrDefault();
            ViewBag.employeeNameBag = employeeName;

            return View(sales);
        }
    }
}