namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ActionLists", "Name", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ActionLists", "Name", c => c.String(nullable: false, maxLength: 20));
        }
    }
}
