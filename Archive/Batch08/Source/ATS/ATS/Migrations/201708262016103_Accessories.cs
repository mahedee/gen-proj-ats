namespace ATS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Accessories : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accessories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompanyId = c.Int(nullable: false),
                        Name = c.String(),
                        CateId = c.Int(nullable: false),
                        ManuId = c.Int(nullable: false),
                        BranchId = c.Int(nullable: false),
                        ModelNo = c.String(),
                        OrderNo = c.String(),
                        PurchaseCost = c.Double(nullable: false),
                        PurchaseDate = c.DateTime(nullable: false),
                        Quantity = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        ActionDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Branches", t => t.BranchId)
                .ForeignKey("dbo.Catagories", t => t.CateId)
                .ForeignKey("dbo.Manufacturers", t => t.ManuId)
                .ForeignKey("dbo.Organizations", t => t.CompanyId)
                .Index(t => t.CompanyId)
                .Index(t => t.CateId)
                .Index(t => t.ManuId)
                .Index(t => t.BranchId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Accessories", "CompanyId", "dbo.Organizations");
            DropForeignKey("dbo.Accessories", "ManuId", "dbo.Manufacturers");
            DropForeignKey("dbo.Accessories", "CateId", "dbo.Catagories");
            DropForeignKey("dbo.Accessories", "BranchId", "dbo.Branches");
            DropIndex("dbo.Accessories", new[] { "BranchId" });
            DropIndex("dbo.Accessories", new[] { "ManuId" });
            DropIndex("dbo.Accessories", new[] { "CateId" });
            DropIndex("dbo.Accessories", new[] { "CompanyId" });
            DropTable("dbo.Accessories");
        }
    }
}
