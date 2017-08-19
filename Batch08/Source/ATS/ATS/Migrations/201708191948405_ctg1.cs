namespace ATS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ctg1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SubCatagories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 80),
                        CateId = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        ActionDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Catagories", t => t.CateId)
                .Index(t => t.CateId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SubCatagories", "CateId", "dbo.Catagories");
            DropIndex("dbo.SubCatagories", new[] { "CateId" });
            DropTable("dbo.SubCatagories");
        }
    }
}
