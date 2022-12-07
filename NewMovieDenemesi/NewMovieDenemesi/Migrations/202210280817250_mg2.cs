namespace NewMovieDenemesi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mg2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.BlogComments", "CommentContents");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BlogComments", "CommentContents", c => c.String());
        }
    }
}
