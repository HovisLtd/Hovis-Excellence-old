using Hovis.Compliance.Web.Models;
using System.Data.Entity.Migrations;

namespace Hovis.Compliance.Web.Migrations
{
    internal partial class Configuration
    {
        private static void SeedDocumentTypes(ApplicationDbContext context)
        {
            var documentTypes = new[]
            {
                new DocumentType {Id = 1, Name = "Policy Manual"},
                new DocumentType {Id = 2, Name = "Procedures Manual"},
                new DocumentType {Id = 3, Name = "Working Templates & Tools"},
                new DocumentType {Id = 4, Name = "Training & Reference"},
                new DocumentType {Id = 5, Name = "Best Practice"},
            };

            foreach (var documentType in documentTypes)
                context.DocumentTypes.AddOrUpdate(app => app.Id, documentType);
        }
    }
}