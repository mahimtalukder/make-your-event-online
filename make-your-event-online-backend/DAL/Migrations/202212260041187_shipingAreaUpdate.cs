namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class shipingAreaUpdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "ShippingAreaId", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "ShippingAreaId", c => c.Int(nullable: false));
        }
    }
}
