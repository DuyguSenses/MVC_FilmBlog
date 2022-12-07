using NewMovieDenemesi.Models.PagesModel.Sınıflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewMovieDenemesi.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime RegisterDate { get; set; } = DateTime.Now;
        public string Image { get; set; }
        public int ErrorPasswordEntry { get; set; } = 0;

        public int RoleId { get; set; } = 1;
        public Role Role { get; set; }


        public List<Blog> Blog { get; set; }
        public List<MovieBlog> MovieBlog { get; set; }

        //public List<BlogComment> BlogComment { get; set; }

        public bool Status { get; set; }
        public bool IsDelete { get; set; }

    }
}