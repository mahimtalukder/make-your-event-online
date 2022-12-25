namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class servicesTableUpdate : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Services", "TentativeDeliveryDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Services", "TentativeDeliveryDate", c => c.DateTime(nullable: false));
        }
    }
}
