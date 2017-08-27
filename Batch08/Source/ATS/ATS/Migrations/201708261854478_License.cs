namespace ATS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class License : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Licenses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        ProductKey = c.String(),
                        Seats = c.Int(nullable: false),
                        CompanyId = c.Int(nullable: false),
                        MenuId = c.Int(nullable: false),
                        LicenseName = c.String(),
                        LicenseEmail = c.String(),
                        Reassignable = c.Boolean(nullable: false),
                        SupplierId = c.Int(nullable: false),
                        OrderNumber = c.String(),
                        PurchaseCost = c.Double(nullable: false),
                        PurchaseDate = c.DateTime(nullable: false),
                        ExpirationDate = c.DateTime(nullable: false),
                        OrderNo = c.String(),
                        Depreciation = c.Boolean(nullable: false),
                        Maintained = c.Boolean(nullable: false),
                        Notes = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        ActionDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Manufacturers", t => t.MenuId)
                .ForeignKey("dbo.Organizations", t => t.CompanyId)
                .ForeignKey("dbo.Suppliers", t => t.SupplierId)
                .Index(t => t.CompanyId)
                .Index(t => t.MenuId)
                .Index(t => t.SupplierId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Licenses", "SupplierId", "dbo.Suppliers");
            DropForeignKey("dbo.Licenses", "CompanyId", "dbo.Organizations");
            DropForeignKey("dbo.Licenses", "MenuId", "dbo.Manufacturers");
            DropIndex("dbo.Licenses", new[] { "SupplierId" });
            DropIndex("dbo.Licenses", new[] { "MenuId" });
            DropIndex("dbo.Licenses", new[] { "CompanyId" });
            DropTable("dbo.Licenses");
        }
    }
}
