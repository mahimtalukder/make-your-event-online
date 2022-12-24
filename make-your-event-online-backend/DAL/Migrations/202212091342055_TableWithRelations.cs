namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TableWithRelations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ActionLists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Logs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ActionId = c.Int(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        UserId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ActionLists", t => t.ActionId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.ActionId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 30),
                        Password = c.String(nullable: false, maxLength: 12),
                        Token = c.String(),
                        UserType = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Username, unique: true);
            
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 50),
                        Phone = c.String(nullable: false, maxLength: 14),
                        ProfilePicture = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Id)
                .Index(t => t.Id)
                .Index(t => t.Email, unique: true);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 50),
                        Phone = c.String(nullable: false, maxLength: 14),
                        Address = c.String(nullable: false, maxLength: 50),
                        ProfilePicture = c.String(nullable: false),
                        ShippingAreaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Id)
                .Index(t => t.Id)
                .Index(t => t.Email, unique: true);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TotalPrice = c.Double(nullable: false),
                        OrderDate = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                        DeliveryDate = c.DateTime(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        ShippingId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.ShippingAddresses", t => t.ShippingId)
                .Index(t => t.CustomerId)
                .Index(t => t.ShippingId);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceId = c.Int(nullable: false),
                        OrderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.Services", t => t.ServiceId, cascadeDelete: true)
                .Index(t => t.ServiceId)
                .Index(t => t.OrderId);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Reating = c.Int(nullable: false),
                        Comment = c.String(nullable: false, maxLength: 100),
                        Date = c.DateTime(nullable: false),
                        CustomerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.OrderDetails", t => t.Id)
                .Index(t => t.Id)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        PricePerUnit = c.Double(nullable: false),
                        TentativeDeliveryDate = c.DateTime(nullable: false),
                        ThumbnailId = c.Int(nullable: false),
                        Availability = c.Int(nullable: false),
                        OrganizerId = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Organizers", t => t.OrganizerId, cascadeDelete: true)
                .Index(t => t.OrganizerId)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Organizers",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 50),
                        Phone = c.String(nullable: false, maxLength: 14),
                        Address = c.String(nullable: false, maxLength: 100),
                        ProfilePicture = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Id)
                .Index(t => t.Id)
                .Index(t => t.Email, unique: true);
            
            CreateTable(
                "dbo.OrganizingAreas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LocationId = c.Int(nullable: false),
                        OrganizerId = c.Int(nullable: false),
                        MainArea = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Locations", t => t.LocationId, cascadeDelete: true)
                .ForeignKey("dbo.Organizers", t => t.OrganizerId, cascadeDelete: true)
                .Index(t => t.LocationId)
                .Index(t => t.OrganizerId);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Division = c.String(nullable: false, maxLength: 50),
                        District = c.String(maxLength: 50),
                        Thana = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ShippingAddresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Address = c.String(nullable: false, maxLength: 200),
                        Tag = c.String(nullable: false, maxLength: 50),
                        LocationId = c.Int(nullable: false),
                        CustomerId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId)
                .ForeignKey("dbo.Locations", t => t.LocationId, cascadeDelete: true)
                .Index(t => t.LocationId)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.ServiceCatalogs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceId = c.Int(nullable: false),
                        Source = c.String(nullable: false),
                        IsThumbnail = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Services", t => t.ServiceId, cascadeDelete: true)
                .Index(t => t.ServiceId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Logs", "UserId", "dbo.Users");
            DropForeignKey("dbo.Customers", "Id", "dbo.Users");
            DropForeignKey("dbo.Orders", "ShippingId", "dbo.ShippingAddresses");
            DropForeignKey("dbo.OrderDetails", "ServiceId", "dbo.Services");
            DropForeignKey("dbo.ServiceCatalogs", "ServiceId", "dbo.Services");
            DropForeignKey("dbo.Services", "OrganizerId", "dbo.Organizers");
            DropForeignKey("dbo.Organizers", "Id", "dbo.Users");
            DropForeignKey("dbo.OrganizingAreas", "OrganizerId", "dbo.Organizers");
            DropForeignKey("dbo.OrganizingAreas", "LocationId", "dbo.Locations");
            DropForeignKey("dbo.ShippingAddresses", "LocationId", "dbo.Locations");
            DropForeignKey("dbo.ShippingAddresses", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Services", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Reviews", "Id", "dbo.OrderDetails");
            DropForeignKey("dbo.Reviews", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.OrderDetails", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Admins", "Id", "dbo.Users");
            DropForeignKey("dbo.Logs", "ActionId", "dbo.ActionLists");
            DropIndex("dbo.ServiceCatalogs", new[] { "ServiceId" });
            DropIndex("dbo.ShippingAddresses", new[] { "CustomerId" });
            DropIndex("dbo.ShippingAddresses", new[] { "LocationId" });
            DropIndex("dbo.OrganizingAreas", new[] { "OrganizerId" });
            DropIndex("dbo.OrganizingAreas", new[] { "LocationId" });
            DropIndex("dbo.Organizers", new[] { "Email" });
            DropIndex("dbo.Organizers", new[] { "Id" });
            DropIndex("dbo.Services", new[] { "CategoryId" });
            DropIndex("dbo.Services", new[] { "OrganizerId" });
            DropIndex("dbo.Reviews", new[] { "CustomerId" });
            DropIndex("dbo.Reviews", new[] { "Id" });
            DropIndex("dbo.OrderDetails", new[] { "OrderId" });
            DropIndex("dbo.OrderDetails", new[] { "ServiceId" });
            DropIndex("dbo.Orders", new[] { "ShippingId" });
            DropIndex("dbo.Orders", new[] { "CustomerId" });
            DropIndex("dbo.Customers", new[] { "Email" });
            DropIndex("dbo.Customers", new[] { "Id" });
            DropIndex("dbo.Admins", new[] { "Email" });
            DropIndex("dbo.Admins", new[] { "Id" });
            DropIndex("dbo.Users", new[] { "Username" });
            DropIndex("dbo.Logs", new[] { "UserId" });
            DropIndex("dbo.Logs", new[] { "ActionId" });
            DropTable("dbo.ServiceCatalogs");
            DropTable("dbo.ShippingAddresses");
            DropTable("dbo.Locations");
            DropTable("dbo.OrganizingAreas");
            DropTable("dbo.Organizers");
            DropTable("dbo.Categories");
            DropTable("dbo.Services");
            DropTable("dbo.Reviews");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Orders");
            DropTable("dbo.Customers");
            DropTable("dbo.Admins");
            DropTable("dbo.Users");
            DropTable("dbo.Logs");
            DropTable("dbo.ActionLists");
        }
    }
}
