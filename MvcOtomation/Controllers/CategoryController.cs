using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOtomation.Models.Classes;

namespace MvcOtomation.Controllers
{
    public class CategoryController : Controller
    {
        Context context = new Context();

        // GET: Category
        public ActionResult Index()
        {
            var categories = context.Categories.ToList();
            return View(categories);
        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            context.Categories.Add(category);
            context.SaveChanges(); 
            return RedirectToAction("Index");
        }

        public ActionResult DeleteCategory(int id)
        {
            var category = context.Categories.Find(id);
            context.Categories.Remove(category);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult FetchCategory(int id)
        {
            var category = context.Categories.Find(id);
            return View("FetchCategory", category);
        }

        public ActionResult UpdateCategory(Category categoryInput)
        {
            var categoryUpdate = context.Categories.Find(categoryInput.Id);
            categoryUpdate.Name = categoryInput.Name;
            context.SaveChanges();
            return RedirectToAction("Index");
            
        }
    }
}