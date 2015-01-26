namespace Hovis.Compliance.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AddHovisExcellenceApplicationTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HovisExcellenceApplications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Key = c.String(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
        }

        public override void Down()
        {
            DropTable("dbo.HovisExcellenceApplications");
        }
    }
}