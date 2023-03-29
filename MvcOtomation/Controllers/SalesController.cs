using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using IronPdf;
using MvcOtomation.Models.Classes;

namespace MvcOtomation.Controllers
{
    public class SalesController : Controller
    {
        Context context = new Context();

        // GET: Sales
        public ActionResult Index()
        {
            var salesTransactions = context.SalesTransactions.ToList();
            return View(salesTransactions);
        }

        [HttpGet]
        public ActionResult AddSales()
        {
            IEnumerable<SelectListItem> ListProduct = (from x in context.Products.ToList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.Name,
                                                       Value = x.Id.ToString()
                                                   }).ToList();
            IEnumerable<SelectListItem> ListCurrent = (from x in context.Currents.ToList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.Name + " "+ x.Surname,
                                                       Value = x.Id.ToString()
                                                   }).ToList();
            IEnumerable<SelectListItem> ListEmployee = (from x in context.Employees.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = x.Name + " " + x.Surname,
                                                    Value = x.Id.ToString()
                                                }).ToList();
            ViewBag.ListProductBag = ListProduct;

            ViewBag.ListCurrentBag = ListCurrent;

            ViewBag.ListEmployeeBag = ListEmployee;
            ViewData["EmployeeId"] = new SelectList(ListEmployee, "Value", "Text");
            ViewData["ProductId"] = new SelectList(ListProduct, "Value", "Text");
            ViewData["CurrentId"] = new SelectList(ListCurrent, "Value", "Text");


            return View();
        }

        [HttpPost]
        public ActionResult AddSales(SalesTransaction SalesTransaction)
        {
            
            SalesTransaction.Time = DateTime.Parse(DateTime.Now.ToShortDateString());
            context.SalesTransactions.Add(SalesTransaction);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult FetchSale(int id)
        {
            IEnumerable<SelectListItem> ListProduct = (from x in context.Products.ToList()
                                                       select new SelectListItem
                                                       {
                                                           Text = x.Name,
                                                           Value = x.Id.ToString()
                                                       }).ToList();
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
            ViewBag.ListProductBag = ListProduct;

            ViewBag.ListCurrentBag = ListCurrent;

            ViewBag.ListEmployeeBag = ListEmployee;
            ViewData["EmployeeId"] = new SelectList(ListEmployee, "Value", "Text");
            ViewData["ProductId"] = new SelectList(ListProduct, "Value", "Text");
            ViewData["CurrentId"] = new SelectList(ListCurrent, "Value", "Text");

            var sales = context.SalesTransactions.Find(id);
            return View("FetchSale", sales);
        }

        public ActionResult UpdateSale(SalesTransaction salesTransactionInput)
        {
            var salesTransactionUpdate = context.SalesTransactions.Find(salesTransactionInput.Id);
            salesTransactionUpdate.EmployeeId = salesTransactionInput.EmployeeId;
            salesTransactionUpdate.ProductId = salesTransactionInput.ProductId;
            salesTransactionUpdate.CurrentId = salesTransactionInput.CurrentId;
            salesTransactionUpdate.UnitPrice = salesTransactionInput.UnitPrice;
            salesTransactionUpdate.Piece = salesTransactionInput.Piece;
            salesTransactionUpdate.Amount = salesTransactionInput.Amount;
 
            context.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult ExportToBrowser(SalesTransaction salesTransactionInput)
        {
            var sales = context.SalesTransactions.Find(salesTransactionInput.Id);
            //SalesReport salesReport = new SalesReport();
            //salesReport.Olustur(sales);
            var Renderer = new HtmlToPdf();

            StringBuilder htmlContent = new StringBuilder();
            htmlContent.AppendLine("<!DOCTYPE html><html><head><meta charset=" + "utf - 8" + "/><style>.invoice-box{max-width: 800px;margin: auto;padding: 30px;border: 1px solid #eee;box-shadow: 0 0 10px rgba(0+ 0+ 0+ 0.15);font-size: 16px;line-height: 24px;font-family: 'Helvetica Neue'+ 'Helvetica'+ Helvetica+ Arial+ sans-serif;color: #555;}.invoice-box table{width: 100%;line-height: inherit;text-align: left;}.invoice-box table td{padding: 5px;vertical-align: top;}.invoice-box table tr td:nth-child(2){text-align: right;}.invoice-box table tr.top table td{padding-bottom: 20px;}.invoice-box table tr.top table td.title{font-size: 45px;line-height: 45px;color: #333;}.invoice-box table tr.information table td{padding-bottom: 40px;}.invoice-box table tr.heading td{background: #eee;border-bottom: 1px solid #ddd;font-weight: bold;}.invoice-box table tr.details td{padding-bottom: 20px;}.invoice-box table tr.item td{border-bottom: 1px solid #eee;}.invoice-box table tr.item.last td{border-bottom: none;}.invoice-box table tr.total td:nth-child(2){border-top: 2px solid #eee;font-weight: bold;}@media only screen and (max-width: 600px){.invoice-box table tr.top table td{width: 100%;display: block;text-align: center;}.invoice-box table tr.information table td{width: 100%;display: block;text-align: center;}}/** RTL **/.invoice-box.rtl{direction: rtl;font-family: Tahoma+ 'Helvetica Neue'+ 'Helvetica'+ Helvetica+ Arial+ sans-serif;}.invoice-box.rtl table{text-align: right;}.invoice-box.rtl table tr td:nth-child(2){text-align: left;}</style></head><body><div class=\"invoice - box\"><table cellpadding=" + "0" + " cellspacing=" + "0" + "><tr class=" + "top" + "><td colspan=" + "2" + "><table><tr><td class=" + "title" + "><p style=" + "font - size:70px" + ">&#128188;Özbek LTD</p></td>");
            htmlContent.AppendLine("<td>Sales #: " + sales.Id + "<br/>Created: " + sales.Time + "<br/>Due: February 1, 2015</td>");
            htmlContent.AppendLine("</tr></table></td></tr><tr class=" + "information" + "><td colspan=" + "2" + "><table><tr><td>Ankara TeknoPark<br/>12345 Sunny Road<br/>Sunnyville, CA 12345</td><td>" + sales.Employee.Name + "<br/>" + sales.Employee.Name + "<br/></td></tr></table></td></tr><tr class=" + "heading" + "><td>Product</td><td></td></tr><tr class=" + "details" + "><td>Product Id</td><td>" + sales.Product.Id + "</td></tr><tr class=" + "details" + "><td>Product Name</td><td>" + sales.Product.Name + "</td></tr><tr class=" + "details" + "><td>Product Brand</td><td>" + sales.Product.Brand + "</td></tr><tr class=" + "heading" + "><td>Item</td><td>Price</td></tr><tr class=" + "item" + "><td>" + sales.Product.Name + "</td><td>" + sales.UnitPrice + "</td></tr><tr class=" + "total" + "><td></td><td>Total: " + sales.Amount + "</td></tr></table></div></body></html>");



            string htmlString = htmlContent.ToString();
            MemoryStream rend = Renderer.RenderHtmlAsPdf(htmlString).Stream;

            HttpContext.Response.AddHeader("Content-Type", "application/pdf");

            HttpContext.Response.AddHeader("Content-Disposition", String.Format("{0}; filename=Print.pdf; size={1}",
              "attachment", rend.Length.ToString()));

            HttpContext.Response.BinaryWrite(rend.ToArray());

            HttpContext.Response.End();
            return View();
        }

    }
}