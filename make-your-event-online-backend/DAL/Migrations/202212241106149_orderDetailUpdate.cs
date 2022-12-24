namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class orderDetailUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderDetails", "Price", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.OrderDetails", "Price");
        }
    }
}
