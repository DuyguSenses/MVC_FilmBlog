using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewMovieDenemesi.Models.PagesModel
{
    public class UserRoleModel
    {
        public User User { get; set; }   
        public List<User> UserList { get; set; }   
        public List<Role> Role { get; set; }
    }
}