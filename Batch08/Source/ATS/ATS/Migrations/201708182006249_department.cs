namespace ATS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class department : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Departments", "BranchId", "dbo.Branches");
            DropForeignKey("dbo.Departments", "Organization_Id", "dbo.Organizations");
            DropIndex("dbo.Departments", new[] { "Organization_Id" });
            DropColumn("dbo.Departments", "CompanyId");
            RenameColumn(table: "dbo.Departments", name: "Organization_Id", newName: "CompanyId");
            AlterColumn("dbo.Departments", "CompanyId", c => c.Int(nullable: false));
            CreateIndex("dbo.Departments", "CompanyId");
            AddForeignKey("dbo.Departments", "BranchId", "dbo.Branches", "Id");
            AddForeignKey("dbo.Departments", "CompanyId", "dbo.Organizations", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Departments", "CompanyId", "dbo.Organizations");
            DropForeignKey("dbo.Departments", "BranchId", "dbo.Branches");
            DropIndex("dbo.Departments", new[] { "CompanyId" });
            AlterColumn("dbo.Departments", "CompanyId", c => c.Int());
            RenameColumn(table: "dbo.Departments", name: "CompanyId", newName: "Organization_Id");
            AddColumn("dbo.Departments", "CompanyId", c => c.Int(nullable: false));
            CreateIndex("dbo.Departments", "Organization_Id");
            AddForeignKey("dbo.Departments", "Organization_Id", "dbo.Organizations", "Id");
            AddForeignKey("dbo.Departments", "BranchId", "dbo.Branches", "Id", cascadeDelete: true);
        }
    }
}
