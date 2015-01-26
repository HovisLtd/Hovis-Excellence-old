using Hovis.Compliance.Web.Models;
using System.Collections.Generic;

namespace Hovis.Compliance.Web.Areas.MasterData.ViewModels
{
    public class PeopleListViewModel
    {
        public class NamedList
        {
            public string Name { get; set; }

            public List<Person> People { get; set; }
        }

        public IEnumerable<NamedList> BySite { get; set; }

        public IEnumerable<NamedList> ByRole { get; set; }
    }
}