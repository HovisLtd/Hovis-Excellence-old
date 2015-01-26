using System.Collections.Generic;
using Hovis.Compliance.Web.Models;

namespace Hovis.Compliance.Web.Areas.MasterData.ViewModels
{
    public class SiteAddEditViewModel
    {
        public IEnumerable<SiteCategory> AvailableSiteCategories { get; set; }

        public Site Site { get; set; }
    }
}