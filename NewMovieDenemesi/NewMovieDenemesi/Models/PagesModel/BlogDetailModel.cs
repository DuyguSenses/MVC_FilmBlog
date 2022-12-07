using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewMovieDenemesi.Models.PagesModel
{
    public class BlogDetailModel
    {
        public Blog SingleBlog { get; set; }
        //public Category SingleCategory { get; set; }

        public List<User> User { get; set; }
        public List<Blog> Blog { get; set; }

        public List<BlogComment> Comments { get; set; }
        public BlogComment SingleBlogComment { get; set; }

    }
}