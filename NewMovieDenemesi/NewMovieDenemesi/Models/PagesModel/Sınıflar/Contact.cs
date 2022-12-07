using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewMovieDenemesi.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }   //konu
        public string MessageContents { get; set; }   //mesajın içeriği
        public bool Status { get; set; }
        public bool IsDelete { get; set; }
    }
}