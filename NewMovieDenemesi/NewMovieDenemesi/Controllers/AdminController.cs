using NewMovieDenemesi.Models.EntityModel;
using NewMovieDenemesi.Models.PagesModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using NewMovieDenemesi.Models.PagesModel.Sınıflar;
using NewMovieDenemesi.Models;

namespace NewMovieDenemesi.Controllers
{
    public class AdminController : Controller
    {
        DataContext db = new DataContext();
        // GET: 


        //[Authorize(Roles = "Admin")]
        public ActionResult Index(/*int id*/)
        {
            BlogCategoryModel model = new BlogCategoryModel();


            
            var degerler = db.Blog.ToList();
             
          
            return View(degerler);
        }


        public ActionResult Movie()
        {
            BlogCategoryModel model = new BlogCategoryModel();
            var degerler2 = db.MovieBlog.ToList();
            return View(degerler2);
        }



        //[Route("~/Admin/Blog/Edit/{id:int}")]

        //[Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult BlogCreate()
        {
            BlogCategoryModel model = new BlogCategoryModel();

            
            model.Category = db.Category.Where(x => x.IsDelete == false && x.Status == true).ToList();
            return View(model);
        }

        [HttpPost]
        //[Route("~/Admin/Blog/Edit/{id:int}")]
        public ActionResult BlogCreate(Blog blog, HttpPostedFileBase Image)
        {


            BlogCategoryModel model = new BlogCategoryModel();
            model.Category = db.Category.Where(x => x.IsDelete == false && x.Status == true).ToList();

            string ImagePath = "";
            string ImageName = "";
            Blog addblog = new Blog();
            if (Image != null && Image.ContentLength > 0)
            {
                ImageName = Guid.NewGuid().ToString() + "-" + Path.GetFileName(Image.FileName);
                ImagePath = Path.Combine(Server.MapPath("~/Content/images/blog"), ImageName);
                Image.SaveAs(ImagePath);
                addblog.Image = ImageName;
            }
            addblog.Title = blog.Title;         
            addblog.Status = blog.Status;
            addblog.UserId = 1;
            addblog.CategoryId = blog.CategoryId;
            db.Blog.Add(addblog);
            db.SaveChanges();

            var id = db.Blog.ToList().LastOrDefault().Id;
            return Redirect("~/Admin/BlogEdit/" + id);
        }

        public ActionResult BlogDelete(int id)
        {
            var b = db.Blog.Find(id);
            if (b.IsDelete == true)
            {
                //b.IsDelete = true;
                db.Blog.Remove(b);
                db.SaveChanges();
            }

          
            return RedirectToAction("Index");

 
        }

        [HttpGet]
        public ActionResult BlogEdit(int id)
        {
 
            var blog = db.Blog.Find(id);

            return View("BlogEdit", blog);
        }

        [HttpPost] 
        public ActionResult BlogEdit(Blog b)
        {
            var blg = db.Blog.Find(b.Id);
            blg.Contents = b.Contents;
            blg.Title = b.Title;
            blg.Image = b.Image;
            blg.dateTime = b.dateTime;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult BlogComment(string Comment,int id)
        {
             


            var blog = db.Blog.Find(id);
            if (blog != null)
            {
                ViewBag.BlogTitle = blog.Title;
                var blogcomment = db.BlogComment.Where(x => x.BlogId == id && x.IsDelete == false).ToList();
                return View(blogcomment);

            }


            return RedirectToAction("Blog");



        }

        [HttpGet]
        public ActionResult CommentView(int id)
        {
            var comment = db.BlogComment.Find(id);
            if (comment != null)
            {
                BlogDetailModel model = new BlogDetailModel()
                {   
                    SingleBlogComment = comment,
                    User = db.User.ToList(),
                    Blog = db.Blog.ToList()
                };
                return View(model);
            }
            return Redirect("~/Admin/BlogComment/" + comment.BlogId);
        }


        [HttpPost]
        public ActionResult CommentView(BlogComment comment)
        {
            var editcomment = db.BlogComment.Find(comment.Id);
            if (editcomment != null)
            {
                editcomment.Status = comment.Status;
                db.SaveChanges();
                return Redirect(Request.UrlReferrer.ToString());
                //return Redirect(Request.Url.AbsoluteUri);
            }
            return RedirectToAction("Blog");
        }


        public ActionResult CommentDelete(int id)
        {
            var comment = db.BlogComment.Find(id);
            if (comment != null)
            {
                comment.IsDelete = true;
                db.SaveChanges();
            }
            return Redirect("~/Admin/BlogComment/" + comment.BlogId);
        }

        public ActionResult Category()
        {
            var category = db.Category.Where(x => x.IsDelete == false && x.Status == true).ToList();

            return View(category);
        }


        [HttpGet]
     
        public ActionResult CategoryCreate()
        {
            return View();
        }
        [HttpPost]
      
        public ActionResult CategoryCreate(Category category, HttpPostedFileBase Image)
        {
            Category addCategory = new Category();

            addCategory = category;
            if (Image != null && Image.ContentLength > 0)
            {
                string ImagePath = "";
                string ImageName = "";

                ImageName = Guid.NewGuid().ToString() + "-" + Path.GetFileName(Image.FileName);
                ImagePath = Path.Combine(Server.MapPath("~/Content/Admin/assets/images/category/"), ImageName);
                Image.SaveAs(ImagePath);
                addCategory.Image = ImageName;
            }
            else
            {
                addCategory.Image = null;
            }


            db.Category.Add(addCategory);
            db.SaveChanges();
            return View();
        }
       
        public ActionResult CategoryDelete(int id)
        {
            var category = db.Category.Find(id);
            if (category != null)
            {
                category.IsDelete = true;
                db.SaveChanges();
            }
            return RedirectToAction("Category");
        }


        [HttpGet]
        public ActionResult CategoryEdit(int id)
        {
            var category = db.Category.Find(id);
            BlogCategoryModel model = new BlogCategoryModel();
            if (category != null)
            {
                 model.Category = db.Category.Where(x => x.IsDelete == false && x.Status == true).ToList();
                return View(model);
            }
             

            return View("CategoryEdit", category);
        }

        [HttpPost]
        public ActionResult CategoryEdit(Category category, HttpPostedFileBase Image)
        {

            var editcategory = db.Category.Find(category.Id);
            BlogCategoryModel model = new BlogCategoryModel();
            if (editcategory != null)
            {
                if (Image != null && Image.ContentLength > 0)
                {
                    string ImagePath = "";
                    string ImageName = "";

                    ImageName = Guid.NewGuid().ToString() + "-" + Path.GetFileName(Image.FileName);
                    ImagePath = Path.Combine(Server.MapPath("~/Content/Admin/assets/images/category"), ImageName);
                    Image.SaveAs(ImagePath);

                    editcategory.Image = ImageName;
                }
                editcategory.Status = category.Status;
                editcategory.Name = category.Name;
                editcategory.Image = category.Image;
                

                db.SaveChanges();
      
                 model.Category = db.Category.Where(x => x.IsDelete == false && x.Status == true).ToList();
            }

            return RedirectToAction("Index");
             
        }
    }




}
