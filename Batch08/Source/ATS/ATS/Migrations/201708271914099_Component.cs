namespace ATS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Component : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Components",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CategoryId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        SerialNo = c.String(),
                        CompanyId = c.Int(nullable: false),
                        BranchId = c.Int(nullable: false),
                        OrderNumber = c.String(),
                        PurchaseDate = c.DateTime(nullable: false),
                        PurchaseCost = c.Double(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        ActionDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Branches", t => t.BranchId)
                .ForeignKey("dbo.Catagories", t => t.CategoryId)
                .ForeignKey("dbo.Organizations", t => t.CompanyId)
                .Index(t => t.CategoryId)
                .Index(t => t.CompanyId)
                .Index(t => t.BranchId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Components", "CompanyId", "dbo.Organizations");
            DropForeignKey("dbo.Components", "CategoryId", "dbo.Catagories");
            DropForeignKey("dbo.Components", "BranchId", "dbo.Branches");
            DropIndex("dbo.Components", new[] { "BranchId" });
            DropIndex("dbo.Components", new[] { "CompanyId" });
            DropIndex("dbo.Components", new[] { "CategoryId" });
            DropTable("dbo.Components");
        }
    }
}
