using Hovis.Compliance.Web.Areas.MasterData.ViewModels;
using Hovis.Compliance.Web.Models;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Hovis.Compliance.Web.Areas.MasterData.Controllers
{
    public class PersonController : MasterDataController
    {
        public ActionResult Index()
        {
            //if you want to order by something other than first name later, i would look at ordering client site
            //take a look at the UI project (the theme) - data tables - these can be sorted client side with javascript

            var peopleBySite = _db.People
                .OrderBy(x => x.FirstName)
                .GroupBy(x => x.Site.Name)
                .ToList()
                .Select(x => new PeopleListViewModel.NamedList { Name = x.Key, People = x.ToList() });

            var peopleByRole = _db.People
                .OrderBy(x => x.FirstName)
                .GroupBy(x => x.Role.Name)
                .ToList()
                .Select(x => new PeopleListViewModel.NamedList { Name = x.Key, People = x.ToList() });

            var viewModel = new PeopleListViewModel
            {
                ByRole = peopleByRole,
                BySite = peopleBySite
            };

            return View(viewModel);
        }

        public ActionResult New()
        {
            var personRoles = _db.PersonRoles.ToList();
            var sites = _db.Sites.ToList();

            if (!personRoles.Any())
            {
                TempData["error"] =
                    string.Format(
                        @"No roles have been created. <a href=""{0}"" class=""alert-link"" > Click here </a> to add a role now.",
                        Url.Action("New", "PersonRole"));

                return RedirectToAction("Index");
            }

            if (!sites.Any())
            {
                TempData["error"] =
                    string.Format(
                        @"No sites have been created. <a href=""{0}"" class=""alert-link"" > Click here </a> to add a site now.",
                        Url.Action("New", "Site"));

                return RedirectToAction("Index");
            }

            var personViewModel = new PersonAddEditViewModel
            {
                AvailablePersonRoles = personRoles,
                AvailableSites = sites,

                Person = new Person()
            };

            return View("NewOrEdit", personViewModel);
        }

        public async Task<ActionResult> Edit(int id)
        {
            var personRoles = _db.PersonRoles.ToList();
            var sites = _db.Sites.ToList();

            var person = await _db.People.
                SingleOrDefaultAsync(x => x.Id.Equals(id));

            if (person == null)
                return new HttpNotFoundResult();

            var personViewModel = new PersonAddEditViewModel
            {
                AvailablePersonRoles = personRoles,
                AvailableSites = sites,

                Person = person
            };

            return View("NewOrEdit", personViewModel);
        }

        [HttpPost]
        public ActionResult Save(Person person)
        {
            if (person.Id != 0)
            {
                _db.People.Attach(person);
                _db.Entry(person).State = EntityState.Modified;
            }
            else
                _db.People.Add(person);

            SaveChanges();

            TempData["success"] = "Person " + person.Name + " saved";

            return RedirectToAction("Index");
        }
    }
}