using Hovis.Compliance.Web.Models;
using System.Data.Entity.Migrations;

namespace Hovis.Compliance.Web.Migrations
{
    internal partial class Configuration
    {
        private static void SeedDocumentCategories(ApplicationDbContext context)
        {
            var documentCategories = new[]
            {
                new DocumentCategory {Id = 1, Name = "Policy or Procedure"},
                new DocumentCategory {Id = 2, Name = "Working Template or Form"},
                new DocumentCategory {Id = 3, Name = "Training or Reference"},
            };

            foreach (var documentCategory in documentCategories)
                context.DocumentCategories.AddOrUpdate(app => app.Id, documentCategory);
        }
    }
}