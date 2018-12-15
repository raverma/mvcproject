namespace SampleMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMovies : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        ReleaseDate = c.DateTime(nullable: false),
                        Genre = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "CustomerTypeId", "dbo.CustomerTypes");
            DropIndex("dbo.Customers", new[] { "CustomerTypeId" });
            DropTable("dbo.Movies");
            DropTable("dbo.CustomerTypes");
            DropTable("dbo.Customers");
        }
    }
}
