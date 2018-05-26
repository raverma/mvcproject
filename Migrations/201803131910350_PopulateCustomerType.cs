namespace SampleMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateCustomerType : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into CustomerTypes (Type) values ('BUS')");
            Sql("Insert into CustomerTypes (Type) values ('HS')");
            Sql("Insert into CustomerTypes (Type) values ('GOV')");
            Sql("Insert into CustomerTypes (Type) values ('EDU')");
            Sql("Insert into CustomerTypes (Type) values ('GRK')");
            Sql("Insert into CustomerTypes (Type) values ('OTH')");
        }
        
        public override void Down()
        {
        }
    }
}
