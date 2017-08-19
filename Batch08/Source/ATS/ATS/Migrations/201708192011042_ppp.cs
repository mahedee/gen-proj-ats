namespace ATS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ppp : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductCatagories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CateId = c.Int(nullable: false),
                        SCateId = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        ActionDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Catagories", t => t.CateId)
                .ForeignKey("dbo.SubCatagories", t => t.SCateId)
                .Index(t => t.CateId)
                .Index(t => t.SCateId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductCatagories", "SCateId", "dbo.SubCatagories");
            DropForeignKey("dbo.ProductCatagories", "CateId", "dbo.Catagories");
            DropIndex("dbo.ProductCatagories", new[] { "SCateId" });
            DropIndex("dbo.ProductCatagories", new[] { "CateId" });
            DropTable("dbo.ProductCatagories");
        }
    }
}
