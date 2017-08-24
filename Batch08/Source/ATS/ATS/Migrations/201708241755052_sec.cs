namespace ATS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sec : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CateTypes",
                c => new
                    {
                        TypeId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        ActionDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.TypeId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CateTypes");
        }
    }
}
