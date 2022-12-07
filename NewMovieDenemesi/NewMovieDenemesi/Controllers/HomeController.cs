using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NewMovieDenemesi.Models.EntityModel;
using NewMovieDenemesi.Models.PagesModel;

namespace NewMovieDenemesi.Controllers
{
    public class HomeController : Controller
    {
        DataContext db = new DataContext();
        public ActionResult Index()
        {
            IndexModel model = new IndexModel()
            {
                 
                Category = db.Category.Where(x => x.Status == true && x.IsDelete == false).ToList(),
                Blog = db.Blog.Where(x => x.Status == true && x.IsDelete == false).Take(6).ToList()
            };

            return View(model);
            
        }


        public ActionResult CategoryDetail(int id)
        {
            var category = db.Category.Find(id);

            if (category != null)
            {
                return View(category);
            }
            else
            {
                return RedirectToAction("index");
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}