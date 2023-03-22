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
        // GET: Category
        public ActionResult Index()
        {
            Context context = new Context();
            var categories = context.Categories.ToList();
            return View(categories);
        }
    }
}