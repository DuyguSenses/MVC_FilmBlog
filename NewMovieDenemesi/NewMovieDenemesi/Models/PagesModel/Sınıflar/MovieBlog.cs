using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewMovieDenemesi.Models.PagesModel.Sınıflar
{
    public class MovieBlog
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Contents { get; set; }
        public DateTime dateTime { get; set; } = DateTime.Now;
        public string Image { get; set; }
        public bool Status { get; set; }
        public bool IsDelete { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }


        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}