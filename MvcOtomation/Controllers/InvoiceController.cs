using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOtomation.Models.Classes;

namespace MvcOtomation.Controllers
{
    public class InvoiceController : Controller
    {
        Context context = new Context();
        // GET: Invoice
        public ActionResult Index()
        {
            var invoices = context.Invoices.ToList();
            return View(invoices);
        }

        [HttpGet]
        public ActionResult AddInvoice()
        {
            
            IEnumerable<SelectListItem> ListCurrent = (from x in context.Currents.ToList()
                                                       select new SelectListItem
                                                       {
                                                           Text = x.Name + " " + x.Surname,
                                                           Value = x.Id.ToString()
                                                       }).ToList();
            IEnumerable<SelectListItem> ListEmployee = (from x in context.Employees.ToList()
                                                        select new SelectListItem
                                                        {
                                                            Text = x.Name + " " + x.Surname,
                                                            Value = x.Id.ToString()
                                                        }).ToList();

            ViewBag.ListCurrentBag = ListCurrent;

            ViewBag.ListEmployeeBag = ListEmployee;
            ViewData["EmployeeId"] = new SelectList(ListEmployee, "Value", "Text");
            ViewData["CurrentId"] = new SelectList(ListCurrent, "Value", "Text");
            return View();
        }

        [HttpPost]
        public ActionResult AddInvoice(Invoice invoice)
        {
            context.Invoices.Add(invoice);
            context.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult FetchInvoices(int invoiceInputId)
        {
            var invoices = context.Invoices.Find(invoiceInputId);

        }
    }
}