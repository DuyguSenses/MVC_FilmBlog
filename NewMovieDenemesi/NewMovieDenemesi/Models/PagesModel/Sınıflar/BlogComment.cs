using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewMovieDenemesi.Models
{
    public class BlogComment
    {
        public int Id { get; set; }

        public string KullaniciAdi { get; set; }
        public string Email { get; set; }
        public string Comment { get; set; }
      
        //public DateTime dateTime { get; set; } = DateTime.Now;

        //public int UserId { get; set; } 
        //public User User { get; set; }

        public int BlogId { get; set; }
        public Blog Blog { get; set; }

        public bool Status { get; set; }
        public bool IsDelete { get; set; }
    }
}