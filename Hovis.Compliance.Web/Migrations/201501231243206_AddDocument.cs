namespace Hovis.Compliance.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AddDocument : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DocumentTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Documents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        IssueNumber = c.String(),
                        IssueDate = c.DateTime(nullable: false),
                        Description = c.String(),
                        Owner = c.String(),
                        ReviewPeriodInMonths = c.Int(nullable: false),
                        FileLink = c.String(),
                        ApplicationId = c.Int(nullable: false),
                        DocumentTypeId = c.Int(nullable: false),
                        DocumentCategoryId = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.HovisExcellenceApplications", t => t.ApplicationId, cascadeDelete: true)
                .ForeignKey("dbo.DocumentCategories", t => t.DocumentCategoryId, cascadeDelete: true)
                .ForeignKey("dbo.DocumentTypes", t => t.DocumentTypeId, cascadeDelete: true)
                .Index(t => t.ApplicationId)
                .Index(t => t.DocumentTypeId)
                .Index(t => t.DocumentCategoryId);

            CreateTable(
                "dbo.DocumentCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
        }

        public override void Down()
        {
            DropForeignKey("dbo.Documents", "DocumentTypeId", "dbo.DocumentTypes");
            DropForeignKey("dbo.Documents", "DocumentCategoryId", "dbo.DocumentCategories");
            DropForeignKey("dbo.Documents", "ApplicationId", "dbo.HovisExcellenceApplications");
            DropIndex("dbo.Documents", new[] { "DocumentCategoryId" });
            DropIndex("dbo.Documents", new[] { "DocumentTypeId" });
            DropIndex("dbo.Documents", new[] { "ApplicationId" });
            DropTable("dbo.DocumentCategories");
            DropTable("dbo.Documents");
            DropTable("dbo.DocumentTypes");
        }
    }
}