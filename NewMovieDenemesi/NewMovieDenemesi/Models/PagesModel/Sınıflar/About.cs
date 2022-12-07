using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewMovieDenemesi.Models
{
    public class About
    {
        public int Id { get; set; }
        public string Explanation { get; set; }
        public bool Status { get; set; }
        public bool IsDelete { get; set; }
    }
}