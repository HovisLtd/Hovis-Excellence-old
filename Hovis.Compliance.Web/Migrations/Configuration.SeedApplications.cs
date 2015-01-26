using Hovis.Compliance.Web.Models;
using System.Data.Entity.Migrations;

namespace Hovis.Compliance.Web.Migrations
{
    internal partial class Configuration
    {
        private static void SeedApplications(ApplicationDbContext context)
        {
            var applications = new[]
            {
                new HovisExcellenceApplication {Id = 1, Name = "Health & Safety", ApplicationKey = "health-and-safety"},
                new HovisExcellenceApplication {Id = 2, Name = "Customer Loyalty", ApplicationKey = "customer-loyalty"},
                new HovisExcellenceApplication {Id = 3, Name = "Environmental Stewardship", ApplicationKey="environment"},
            };

            foreach (var application in applications)
                context.Applications.AddOrUpdate(app => app.Id, application);
        }
    }
}