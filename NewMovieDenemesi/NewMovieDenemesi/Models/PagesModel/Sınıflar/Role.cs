using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewMovieDenemesi.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<User> User { get; set; }
        public bool Status { get; set; }
        public bool IsDelete { get; set; }
    }
}