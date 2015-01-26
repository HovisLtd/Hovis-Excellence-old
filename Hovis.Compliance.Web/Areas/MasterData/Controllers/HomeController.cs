using System.Web.Mvc;

namespace Hovis.Compliance.Web.Areas.MasterData.Controllers
{
    public class HomeController : MasterDataController
    {
        // GET: MasterData/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}