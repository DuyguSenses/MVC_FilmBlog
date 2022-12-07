namespace NewMovieDenemesi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mg3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BlogComments", "UserId", "dbo.Users");
            DropIndex("dbo.BlogComments", new[] { "UserId" });
            AddColumn("dbo.BlogComments", "KullaniciAdi", c => c.String());
            AddColumn("dbo.BlogComments", "Email", c => c.String());
            DropColumn("dbo.BlogComments", "dateTime");
            DropColumn("dbo.BlogComments", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BlogComments", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.BlogComments", "dateTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.BlogComments", "Email");
            DropColumn("dbo.BlogComments", "KullaniciAdi");
            CreateIndex("dbo.BlogComments", "UserId");
            AddForeignKey("dbo.BlogComments", "UserId", "dbo.Users", "Id");
        }
    }
}
