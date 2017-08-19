namespace ATS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class emp : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompanyId = c.Int(nullable: false),
                        BranchId = c.Int(nullable: false),
                        DeptId = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 80),
                        Code = c.String(nullable: false, maxLength: 4),
                        CreateDate = c.DateTime(nullable: false),
                        ActionDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Branches", t => t.BranchId)
                .ForeignKey("dbo.Departments", t => t.DeptId)
                .ForeignKey("dbo.Organizations", t => t.CompanyId)
                .Index(t => t.CompanyId)
                .Index(t => t.BranchId)
                .Index(t => t.DeptId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "CompanyId", "dbo.Organizations");
            DropForeignKey("dbo.Employees", "DeptId", "dbo.Departments");
            DropForeignKey("dbo.Employees", "BranchId", "dbo.Branches");
            DropIndex("dbo.Employees", new[] { "DeptId" });
            DropIndex("dbo.Employees", new[] { "BranchId" });
            DropIndex("dbo.Employees", new[] { "CompanyId" });
            DropTable("dbo.Employees");
        }
    }
}
