using Hovis.Excellence.Web.Areas.MasterData.ViewModels;
using Hovis.Excellence.Web.Controllers;
using Hovis.Excellence.Web.Identity;
using Hovis.Excellence.Web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Hovis.Excellence.Web.Areas.MasterData.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DocumentController : HovisExcellenceController
    {
        private ApplicationUserManager _userManager;

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
        }

        public ActionResult Index()
        {
            var viewModel = new DocumentListViewModel
            {
                Applications = _db.Applications.OrderBy(x => x.Name).ToList(),
                Documents = _db.Documents.ToList(),
            };

            return View(viewModel);
        }

        public ActionResult New()
        {
            var documentCategories = _db.DocumentCategories.ToList();
            var documentTypes = _db.DocumentTypes.ToList();
            var apps = _db.Applications.ToList();

            var viewModel = new NewDocumentViewModel
            {
                Document = new Document(),
                DocumentCategories = documentCategories,
                DocumentTypes = documentTypes,
                Applcations = apps
            };

            return View("NewOrEdit", viewModel);
        }

        public async Task<ActionResult> Edit(int id)
        {
            var document = await _db.Documents.SingleOrDefaultAsync(x => x.Id.Equals(id));

            if (document == null)
                return new HttpNotFoundResult();

            var documentCategories = _db.DocumentCategories.ToList();
            var documentTypes = _db.DocumentTypes.ToList();
            var apps = _db.Applications.ToList();

            var viewModel = new NewDocumentViewModel
            {
                Document = document,
                DocumentCategories = documentCategories,
                DocumentTypes = documentTypes,
                Applcations = apps
            };

            return View("NewOrEdit", viewModel);
        }

        public ActionResult Save(Document document)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("New", document);

            if (document.Id != 0)
            {
                _db.Documents.Attach(document);
                _db.Entry(document).State = EntityState.Modified;
            }
            else
                _db.Documents.Add(document);

            SaveChanges();

            TempData["success"] = "Document " + document.Title + " saved";

            return RedirectToAction("Index");
        }
    }

    public class NewDocumentViewModel
    {
        public NewDocumentViewModel()
        {
            var values = new[] { 0, 1, 3, 6, 9, 12, 18, 24 }
                .Select(x => new SelectListItem
            {
                Value = x.ToString(),
                Text = (x > 0) ? x.ToString() + " Months" : "Not Applicable" //0 = not applicable
            });

            ReviewPeriods = new SelectList(values, "Value", "Text");
        }

        public Document Document { get; set; }

        public IEnumerable<DocumentCategory> DocumentCategories { get; set; }

        public IEnumerable<DocumentType> DocumentTypes { get; set; }

        public IEnumerable<HovisExcellenceApplication> Applcations { get; set; }

        public IEnumerable<SelectListItem> ReviewPeriods { get; set; }
    }
}