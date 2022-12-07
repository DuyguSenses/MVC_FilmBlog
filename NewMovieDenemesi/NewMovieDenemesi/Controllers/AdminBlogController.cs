using NewMovieDenemesi.Models.PagesModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using NewMovieDenemesi.Models.EntityModel;
using NewMovieDenemesi.Models;
using NewMovieDenemesi.Models.PagesModel.Sınıflar;

namespace NewMovieDenemesi.Controllers
{
    public class AdminBlogController : Controller
    {
        Comments c = new Comments();

        DataContext db = new DataContext();
        // GET: AdminBlog


        [Route("~/Admin/Blog/Index/{id:int}")]

        //[Authorize(Roles = "Admin")]
        public ActionResult Index(Blog blog)
        {

            var bloglar = db.Blog.Where(x => x.CategoryId== 28).ToList();

             return View(bloglar);
        }
        //[Route("~/Admin/Blog/Görünüm/{id:int}")]

        //[Authorize(Roles = "Admin")]

        public ActionResult Book(Blog blog)
        {
            var book = db.Blog.Where(x => x.CategoryId == 3).ToList();

             return View(book);
        }


        public ActionResult MovieList(Blog blog)
        {


 
            var movie = db.Blog.Where(x => x.CategoryId == 26).ToList();

             return View(movie);
        }



        public ActionResult Görünüm(int id)
        {
             c.Deger1 = db.Blog.Where(x => x.Id == id).ToList();
            c.Deger2 = db.BlogComment.Where(x => x.BlogId == id).ToList();

            return View(c);
                
        }

        [HttpGet]

        public PartialViewResult YorumYap(int id)
        {
            ViewBag.deger = id;
            return PartialView();
        }


        [HttpPost]
        public PartialViewResult YorumYap(BlogComment by)
        {
            db.BlogComment.Add(by);
            db.SaveChanges();
            return PartialView();
        }


    }
}
 