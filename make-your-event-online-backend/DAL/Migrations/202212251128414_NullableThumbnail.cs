namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NullableThumbnail : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Services", "ThumbnailId", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Services", "ThumbnailId", c => c.Int(nullable: false));
        }
    }
}
