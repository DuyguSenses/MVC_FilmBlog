using NewMovieDenemesi.Models.PagesModel.Sınıflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewMovieDenemesi.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public bool Status { get; set; }
        public bool IsDelete { get; set; }

        public List<Blog> Blog { get; set; }
        public List<MovieBlog> MovieBlog { get; set; }

    }
}