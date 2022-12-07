using NewMovieDenemesi.Models.PagesModel.Sınıflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewMovieDenemesi.Models.PagesModel
{
    public class BlogCategoryModel
    {
        //public List<MovieBlog> MovieBlog { get; set; }
        //public MovieBlog SingleMovieBlog { get; set; }
        public List<Blog> Blog { get; set; }
        public Blog SingleBlog { get; set; }
        public List<MovieBlog> MovieBlog { get; set; }
        public MovieBlog SingleMovieBlog { get; set; }
        public List<Category> Category { get; set; } 
    
    }
}