namespace ATS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fifth : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Models",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        MenuId = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        ModelNo = c.String(),
                        Depreciation = c.Boolean(nullable: false),
                        Eol = c.Int(nullable: false),
                        FieldsetId = c.Int(nullable: false),
                        Note = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        ActionDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Catagories", t => t.CategoryId)
                .ForeignKey("dbo.Fieldsets", t => t.FieldsetId)
                .ForeignKey("dbo.Manufacturers", t => t.MenuId)
                .Index(t => t.MenuId)
                .Index(t => t.CategoryId)
                .Index(t => t.FieldsetId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Models", "MenuId", "dbo.Manufacturers");
            DropForeignKey("dbo.Models", "FieldsetId", "dbo.Fieldsets");
            DropForeignKey("dbo.Models", "CategoryId", "dbo.Catagories");
            DropIndex("dbo.Models", new[] { "FieldsetId" });
            DropIndex("dbo.Models", new[] { "CategoryId" });
            DropIndex("dbo.Models", new[] { "MenuId" });
            DropTable("dbo.Models");
        }
    }
}
