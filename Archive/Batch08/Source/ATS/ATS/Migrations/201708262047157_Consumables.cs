namespace ATS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Consumables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Consumables",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompanyId = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        ManuId = c.Int(nullable: false),
                        BranchId = c.Int(nullable: false),
                        ModelNo = c.String(),
                        ItemNo = c.String(),
                        OrderNo = c.String(),
                        PurchaseCost = c.Double(nullable: false),
                        PurchaseDate = c.DateTime(nullable: false),
                        Quantity = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        ActionDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Branches", t => t.BranchId)
                .ForeignKey("dbo.Catagories", t => t.CategoryId)
                .ForeignKey("dbo.Manufacturers", t => t.ManuId)
                .ForeignKey("dbo.Organizations", t => t.CompanyId)
                .Index(t => t.CompanyId)
                .Index(t => t.CategoryId)
                .Index(t => t.ManuId)
                .Index(t => t.BranchId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Consumables", "CompanyId", "dbo.Organizations");
            DropForeignKey("dbo.Consumables", "ManuId", "dbo.Manufacturers");
            DropForeignKey("dbo.Consumables", "CategoryId", "dbo.Catagories");
            DropForeignKey("dbo.Consumables", "BranchId", "dbo.Branches");
            DropIndex("dbo.Consumables", new[] { "BranchId" });
            DropIndex("dbo.Consumables", new[] { "ManuId" });
            DropIndex("dbo.Consumables", new[] { "CategoryId" });
            DropIndex("dbo.Consumables", new[] { "CompanyId" });
            DropTable("dbo.Consumables");
        }
    }
}
