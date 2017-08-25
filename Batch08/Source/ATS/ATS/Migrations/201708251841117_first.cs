namespace ATS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Assets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompanyId = c.Int(nullable: false),
                        AssetTag = c.String(nullable: false),
                        ModelId = c.Int(nullable: false),
                        StatusId = c.Int(nullable: false),
                        Serial = c.String(),
                        Name = c.String(nullable: false),
                        PurchaseDate = c.DateTime(nullable: false),
                        SupplierId = c.Int(nullable: false),
                        OrderNumber = c.String(),
                        Cost = c.Double(nullable: false),
                        Warranty = c.String(),
                        BranchId = c.Int(nullable: false),
                        Note = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        ActionDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Branches", t => t.BranchId)
                .ForeignKey("dbo.Models", t => t.ModelId)
                .ForeignKey("dbo.Organizations", t => t.CompanyId)
                .ForeignKey("dbo.Status", t => t.StatusId)
                .ForeignKey("dbo.Suppliers", t => t.SupplierId)
                .Index(t => t.CompanyId)
                .Index(t => t.ModelId)
                .Index(t => t.StatusId)
                .Index(t => t.SupplierId)
                .Index(t => t.BranchId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Assets", "SupplierId", "dbo.Suppliers");
            DropForeignKey("dbo.Assets", "StatusId", "dbo.Status");
            DropForeignKey("dbo.Assets", "CompanyId", "dbo.Organizations");
            DropForeignKey("dbo.Assets", "ModelId", "dbo.Models");
            DropForeignKey("dbo.Assets", "BranchId", "dbo.Branches");
            DropIndex("dbo.Assets", new[] { "BranchId" });
            DropIndex("dbo.Assets", new[] { "SupplierId" });
            DropIndex("dbo.Assets", new[] { "StatusId" });
            DropIndex("dbo.Assets", new[] { "ModelId" });
            DropIndex("dbo.Assets", new[] { "CompanyId" });
            DropTable("dbo.Assets");
        }
    }
}
