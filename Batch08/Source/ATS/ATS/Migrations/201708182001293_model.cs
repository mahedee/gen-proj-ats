namespace ATS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class model : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Branches", "Organization_Id", "dbo.Organizations");
            DropIndex("dbo.Branches", new[] { "Organization_Id" });
            DropColumn("dbo.Branches", "CompanyId");
            RenameColumn(table: "dbo.Branches", name: "Organization_Id", newName: "CompanyId");
            AlterColumn("dbo.Branches", "CompanyId", c => c.Int(nullable: false));
            CreateIndex("dbo.Branches", "CompanyId");
            AddForeignKey("dbo.Branches", "CompanyId", "dbo.Organizations", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Branches", "CompanyId", "dbo.Organizations");
            DropIndex("dbo.Branches", new[] { "CompanyId" });
            AlterColumn("dbo.Branches", "CompanyId", c => c.Int());
            RenameColumn(table: "dbo.Branches", name: "CompanyId", newName: "Organization_Id");
            AddColumn("dbo.Branches", "CompanyId", c => c.Int(nullable: false));
            CreateIndex("dbo.Branches", "Organization_Id");
            AddForeignKey("dbo.Branches", "Organization_Id", "dbo.Organizations", "Id");
        }
    }
}
