using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using NewMovieDenemesi.Models.PagesModel.Sınıflar;

namespace NewMovieDenemesi.Models.EntityModel
{
    public class DataContext:DbContext
    {
        public DataContext() : base("DbConnect") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();//çoka çok diagram ilişkileri
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();//bire çok diagram ilişkileri
        }

        public DbSet<MovieBlog> MovieBlog { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<User> User { get; set; }  
        public DbSet<Category> Category { get; set; }
        public DbSet<Blog> Blog { get; set; }
        public DbSet<BlogComment> BlogComment { get; set; }
    }
}