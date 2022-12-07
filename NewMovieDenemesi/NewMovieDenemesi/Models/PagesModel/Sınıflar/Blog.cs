using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewMovieDenemesi.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Contents { get; set; }
        public DateTime dateTime { get; set; } = DateTime.Now;
        public string Image { get; set; }
        public bool Status { get; set; }
        public bool IsDelete { get; set; }

        public int MyProperty { get; set; }


        //public int TypeId { get; set; }
        //public Type Type { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }


        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public List<BlogComment> BlogComment { get; set; }
    }
}