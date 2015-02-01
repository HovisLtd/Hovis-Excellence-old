using Hovis.Excellence.Web.Areas.AppShared;
using Hovis.Excellence.Web.Controllers;
using System.Linq;
using System.Web.Mvc;

namespace Hovis.Excellence.Web.Areas.HealthAndSafety.Controllers
{
    public class HomeController : HovisExcellenceController
    {
        public ActionResult Index()
        {
            var documents = _db.Documents
                .Where(x => x.ApplicationId.Equals(1)) //this is in the database - it's seeded by the seed methods
                .ToList()
                .GroupBy(x => x.DocumentCategory)
                .Select(x => new DocumentListViewModel { DocumentCategory = x.Key.Name, Documents = x.ToList() });

            return View(documents);
        }
    }
}