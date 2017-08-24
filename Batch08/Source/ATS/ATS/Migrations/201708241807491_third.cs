namespace ATS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class third : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Catagories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                        CateTypeId = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        ActionDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CateTypes", t => t.CateTypeId)
                .Index(t => t.CateTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Catagories", "CateTypeId", "dbo.CateTypes");
            DropIndex("dbo.Catagories", new[] { "CateTypeId" });
            DropTable("dbo.Catagories");
        }
    }
}
