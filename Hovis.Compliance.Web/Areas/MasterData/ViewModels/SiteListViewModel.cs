using Hovis.Compliance.Web.Models;
using System.Collections.Generic;

namespace Hovis.Compliance.Web.Areas.MasterData.ViewModels
{
    public class SiteListViewModel
    {
        public string CategoryName { get; set; }

        public List<Site> Sites { get; set; }
    }
}