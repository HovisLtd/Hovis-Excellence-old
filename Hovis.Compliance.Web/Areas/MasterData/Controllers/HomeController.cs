using System.Web.Mvc;
using Hovis.Compliance.Web.Controllers;

namespace Hovis.Compliance.Web.Areas.MasterData.Controllers
{
    public class HomeController : HovisExcellenceController
    {
        // GET: MasterData/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}