using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOtomation.Models.Classes;

namespace MvcOtomation.Controllers
{
    public class ProductController : Controller
    {
        Context context = new Context();
        // GET: Product


        public ActionResult Index()
        {
            var products = context.Products.Where(x => x.State == true).ToList();
            return View(products);
        }

        [HttpGet]
        public ActionResult AddProduct()
        {
            List<SelectListItem> ListCategory = (from x in context.Categories.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.Name,
                                                     Value = x.Id.ToString()
                                                 }).ToList();

            List<SelectListItem> ListState = new List<SelectListItem>();
            ListState.Add(new SelectListItem { Text = true.ToString(), Value = true.ToString() });
            ListState.Add(new SelectListItem { Text = false.ToString(), Value = false.ToString() });


            ViewBag.ListStateBag = ListState;

            ViewBag.ListCategoryBag = ListCategory;
            return View();
        }

        [HttpPost]
        public ActionResult AddProduct(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteProduct(int Id)
        {
            var DeleteProduct = context.Products.Find(Id);
            DeleteProduct.State = false;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult FetchProduct(int id)
        {
            var products = context.Products.Find(id);
            List<SelectListItem> ListCategory = (from x in context.Categories.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.Name,
                                                     Value = x.Id.ToString()
                                                 }).ToList();

            List<SelectListItem> ListState = new List<SelectListItem>();
            ListState.Add(new SelectListItem { Text = true.ToString(), Value = true.ToString() });
            ListState.Add(new SelectListItem { Text = false.ToString(), Value = false.ToString() });


            ViewBag.ListStateBag = ListState;

            ViewBag.ListCategoryBag = ListCategory;
            return View("FetchProduct", products);
        }

        public ActionResult UpdateProduct(Product productInput)
        {
            var productUpdate = context.Products.Find(productInput.Id);
            productUpdate.Name = productInput.Name;
            productUpdate.Brand = productInput.Brand;
            productUpdate.Stock = productInput.Stock;
            productUpdate.PurchasePrice = productInput.PurchasePrice;
            productUpdate.SalePice = productInput.SalePice;
            productUpdate.State = productInput.State;
            productUpdate.Photo = productInput.Photo;
            productUpdate.CategoryId = productInput.CategoryId;

            context.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}