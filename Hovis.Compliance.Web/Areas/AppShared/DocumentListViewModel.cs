using Hovis.Compliance.Web.Models;
using System.Collections.Generic;

namespace Hovis.Compliance.Web.Areas.AppShared
{
    public class DocumentListViewModel
    {
        public string DocumentCategory { get; set; }

        public IEnumerable<Document> Documents { get; set; }
    }
}