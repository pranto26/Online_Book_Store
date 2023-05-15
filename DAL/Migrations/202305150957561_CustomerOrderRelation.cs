namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerOrderRelation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "Customer_Id", c => c.Int());
            CreateIndex("dbo.Orders", "Customer_Id");
            AddForeignKey("dbo.Orders", "Customer_Id", "dbo.Customers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.Orders", new[] { "Customer_Id" });
            DropColumn("dbo.Orders", "Customer_Id");
        }
    }
}
