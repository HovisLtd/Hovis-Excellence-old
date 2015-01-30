using Hovis.Compliance.Web.Areas.AppShared;
using Hovis.Compliance.Web.Controllers;
using System.Linq;
using System.Web.Mvc;

namespace Hovis.Compliance.Web.Areas.CustomerLoyalty.Controllers
{
    public class HomeController : HovisExcellenceController
    {
        public ActionResult Index()
        {
            var documents = _db.Documents
                .Where(x => x.Applciation.ApplicationKey == "customer-loyalty") //this is in the database - it's seeded by the seed methods
                .GroupBy(x => x.DocumentCategory)
                .Select(x => new DocumentListViewModel { DocumentCategory = x.Key.Name, Documents = x.ToList() })
                .ToList();

            return View(documents);
        }
    }
}