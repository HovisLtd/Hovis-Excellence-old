namespace Hovis.Compliance.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeDocumentFileLinkRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Documents", "FileLink", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Documents", "FileLink", c => c.String());
        }
    }
}
