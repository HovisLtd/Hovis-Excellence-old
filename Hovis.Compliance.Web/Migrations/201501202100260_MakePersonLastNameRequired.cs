namespace Hovis.Compliance.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakePersonLastNameRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.People", "LastName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.People", "LastName", c => c.String());
        }
    }
}
