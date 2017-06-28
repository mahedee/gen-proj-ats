namespace ATS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserContextss : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Organizations");
            AddColumn("dbo.Organizations", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Organizations", "CreateBy", c => c.String());
            AddColumn("dbo.Organizations", "ModifiedBy", c => c.String());
            AddColumn("dbo.Organizations", "CreateDate", c => c.String());
            AddColumn("dbo.Organizations", "ActionDate", c => c.String());
            AlterColumn("dbo.Organizations", "Name", c => c.String());
            AddPrimaryKey("dbo.Organizations", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Organizations");
            AlterColumn("dbo.Organizations", "Name", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Organizations", "ActionDate");
            DropColumn("dbo.Organizations", "CreateDate");
            DropColumn("dbo.Organizations", "ModifiedBy");
            DropColumn("dbo.Organizations", "CreateBy");
            DropColumn("dbo.Organizations", "Id");
            AddPrimaryKey("dbo.Organizations", "Name");
        }
    }
}
