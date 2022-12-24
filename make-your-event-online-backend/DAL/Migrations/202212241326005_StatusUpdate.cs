namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StatusUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderDetails", "Status", c => c.Int(nullable: false));
            DropColumn("dbo.Orders", "Status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "Status", c => c.Int(nullable: false));
            DropColumn("dbo.OrderDetails", "Status");
        }
    }
}
