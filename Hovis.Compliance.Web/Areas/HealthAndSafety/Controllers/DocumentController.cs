using System.Linq;
using System.Web.Mvc;
using Hovis.Compliance.Web.Controllers;

namespace Hovis.Compliance.Web.Areas.HealthAndSafety.Controllers
{
    public class DocumentController : HovisExcellenceController
    {
        public ActionResult Index(int id)
        {
            var document = _db.Documents.SingleOrDefault(x => x.Id.Equals(id));

            if (document == null)
                return new HttpNotFoundResult();

            return View(document);
        }
    }
}