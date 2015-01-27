﻿using Hovis.Compliance.Web.Models;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Hovis.Compliance.Web.Areas.MasterData.Controllers
{
    public class PersonRoleController : MasterDataController
    {
        public ActionResult Index()
        {
            var personroles = _db.PersonRoles
                .OrderBy(x => x.Name)
                .ToList();

            return View(personroles);
        }

        public ActionResult New()
        {
            return View("NewOrEdit", new PersonRole());
        }

        public async Task<ActionResult> Edit(int id)
        {
            var personRole = await _db.PersonRoles
                .SingleOrDefaultAsync(x => x.Id.Equals(id));

            if (personRole == null)
                return new HttpNotFoundResult();

            return View("NewOrEdit", personRole);
        }

        [HttpPost]
        public ActionResult Save(PersonRole personRole)
        {
            if (personRole.Id != 0)
            {
                _db.PersonRoles.Attach(personRole);
                _db.Entry(personRole).State = EntityState.Modified;
            }
            else
                _db.PersonRoles.Add(personRole);

            _db.SaveChanges();

            TempData["success"] = "Person Role " + personRole.Name + " saved";

            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Delete(int id)
        {
            var personRole = await _db.PersonRoles.SingleOrDefaultAsync(x => x.Id.Equals(id));

            if (personRole == null)
                return new HttpNotFoundResult();

            return View(personRole);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> DeleteConfirm(int id)
        {
            var personRole = await _db.PersonRoles.SingleOrDefaultAsync(x => x.Id.Equals(id));

            if (personRole == null)
                return new HttpNotFoundResult();

            _db.PersonRoles.Remove(personRole);
            _db.SaveChanges();

            TempData["success"] = "Person role " + personRole.Name + " deleted successfully";

            return RedirectToAction("Index");
        }
    }
}