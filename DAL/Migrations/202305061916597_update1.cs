namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "Book_Id", c => c.Int());
            CreateIndex("dbo.Orders", "Book_Id");
            AddForeignKey("dbo.Orders", "Book_Id", "dbo.Books", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "Book_Id", "dbo.Books");
            DropIndex("dbo.Orders", new[] { "Book_Id" });
            DropColumn("dbo.Orders", "Book_Id");
        }
    }
}
