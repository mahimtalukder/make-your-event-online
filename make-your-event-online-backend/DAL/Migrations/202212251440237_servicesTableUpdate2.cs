namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class servicesTableUpdate2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Services", "TentativeDeliveryDate", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Services", "TentativeDeliveryDate");
        }
    }
}
