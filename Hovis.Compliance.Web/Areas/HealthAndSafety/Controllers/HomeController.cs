using Hovis.Compliance.Web.Controllers;
using Hovis.Compliance.Web.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Hovis.Compliance.Web.Areas.HealthAndSafety.Controllers
{
    public class HomeController : HovisExcellenceController
    {
        public ActionResult Index()
        {
            var documents = _db.Documents
                .Where(x => x.Applciation.ApplicationKey == "health-and-safety") //this is in the database - it's seeded by the seed methods
                .GroupBy(x => x.DocumentCategory)
                .Select(x => new DocumentListViewModel { DocumentCategory = x.Key.Name, Documents = x.ToList() })
                .ToList();

            return View(documents);
        }
    }

    public class DocumentListViewModel
    {
        public string DocumentCategory { get; set; }

        public IEnumerable<Document> Documents { get; set; }
    }
}