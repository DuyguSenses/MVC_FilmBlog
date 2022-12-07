using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using NewMovieDenemesi.Models.EntityModel;

namespace NewMovieDenemesi.Controllers
{
    public class AdminLoginController : Controller
    {
        DataContext db = new DataContext();
        // GET: AdminLogin
        public ActionResult Index()
        {
            return View();

        }


        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]


        
        public ActionResult Login(string Username, string Password, bool? Remember)
        {
            var userControl = db.User.FirstOrDefault(x => x.Username == Username && x.Password == Password);
            if (userControl != null)
            {
                if (userControl.IsDelete == false)
                {
                    bool benihatirla = Remember == null ? false : true;
                    FormsAuthentication.SetAuthCookie(userControl.Username, benihatirla);
                    ViewBag.Mesaj = "Merhaba " + Username;
                    return RedirectToAction("index");
                }
                else
                {
                    ViewBag.Mesaj = "Bu kullanıcı hesabı silinmiştir";
                }

            }
            else
            {
                ViewBag.Mesaj = "Kullanıcı Adı veya Şifre Hatalı";
            }

            return View();
        }
      
        public ActionResult Logout()
            {
                FormsAuthentication.SignOut();
                return RedirectToAction("Login");
            }
        
    }
}