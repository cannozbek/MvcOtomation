using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOtomation.Models.Classes;


namespace MvcOtomation.Controllers
{
    public class CurrentController : Controller
    {
        Context context = new Context();
        // GET: Current
        public ActionResult Index()
        {
            var currents = context.Currents.Where(x => x.State == true).ToList();
            return View(currents);
        }

        [HttpGet]
        public ActionResult AddCurrent()
        {
            List<SelectListItem> ListState = new List<SelectListItem>();
            ListState.Add(new SelectListItem { Text = true.ToString(), Value = true.ToString() });
            ListState.Add(new SelectListItem { Text = false.ToString(), Value = false.ToString() });


            ViewBag.ListStateBag = ListState;
            return View();
        }

        [HttpPost]
        public ActionResult AddCurrent(Current current)
        {
            context.Currents.Add(current);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteCurrent(int Id)
        {
            var DeleteCurrent = context.Currents.Find(Id);
            DeleteCurrent.State = false;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult FetchCurrent(int id)
        {

            List<SelectListItem> ListState = new List<SelectListItem>();
            ListState.Add(new SelectListItem { Text = true.ToString(), Value = true.ToString() });
            ListState.Add(new SelectListItem { Text = false.ToString(), Value = false.ToString() });


            ViewBag.ListStateBag = ListState;

            var current = context.Currents.Find(id);
            return View("FetchCurrent", current);
        }

        public ActionResult UpdateCurrent(Current currentInput)
        {
            var currentUpdate = context.Currents.Find(currentInput.Id);
            currentUpdate.Name = currentInput.Name;
            currentUpdate.Surname = currentInput.Surname;
            currentUpdate.City = currentInput.City;
            currentUpdate.Mail = currentInput.Mail;
            currentUpdate.State = currentInput.State;


            context.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}