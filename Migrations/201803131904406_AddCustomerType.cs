namespace SampleMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCustomerType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "CustomerTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Customers", "CustomerTypeId");
            AddForeignKey("dbo.Customers", "CustomerTypeId", "dbo.CustomerTypes", "Id", cascadeDelete: true);
            DropColumn("dbo.Customers", "CustomerType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "CustomerType", c => c.String());
            DropForeignKey("dbo.Customers", "CustomerTypeId", "dbo.CustomerTypes");
            DropIndex("dbo.Customers", new[] { "CustomerTypeId" });
            DropColumn("dbo.Customers", "CustomerTypeId");
        }
    }
}
