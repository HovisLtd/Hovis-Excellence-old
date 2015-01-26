using Hovis.Compliance.Web.Models;
using System.Collections.Generic;

namespace Hovis.Compliance.Web.Areas.MasterData.ViewModels
{
    public class DocumentListViewModel
    {
        public IEnumerable<Document> Documents { get; set; }

        public IEnumerable<HovisExcellenceApplication> Applications { get; set; }
    }
}