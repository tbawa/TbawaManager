using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MemberManager.Models;

namespace MemberManager.Controllers
{
    [Authorize]
    public class OfficeBearersController : Controller
    {
        private tbawaEntities db = new tbawaEntities();

        // GET: OfficeBearers
        public ActionResult Index()
        {
            var officeBearers = db.OfficeBearers.Include(o => o.Role).Include(o => o.Person);
            return View(officeBearers.ToList());
        }

        // GET: OfficeBearers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OfficeBearer officeBearer = db.OfficeBearers.Find(id);
            if (officeBearer == null)
            {
                return HttpNotFound();
            }
            return View(officeBearer);
        }

        // GET: OfficeBearers/Create
        public ActionResult Create()
        {
            ViewBag.RoleId = new SelectList(db.Roles, "RoleId", "Name");
            ViewBag.PersonId = new SelectList(db.People, "PersonId", "FirstName");
            return View();
        }

        // POST: OfficeBearers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RoleId,PersonId,StartDate,EndDate,Email")] OfficeBearer officeBearer)
        {
            if (ModelState.IsValid)
            {
                db.OfficeBearers.Add(officeBearer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RoleId = new SelectList(db.Roles, "RoleId", "Name", officeBearer.RoleId);
            ViewBag.PersonId = new SelectList(db.People, "PersonId", "FirstName", officeBearer.PersonId);
            return View(officeBearer);
        }

        // GET: OfficeBearers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OfficeBearer officeBearer = db.OfficeBearers.Find(id);
            if (officeBearer == null)
            {
                return HttpNotFound();
            }
            ViewBag.RoleId = new SelectList(db.Roles, "RoleId", "Name", officeBearer.RoleId);
            ViewBag.PersonId = new SelectList(db.People, "PersonId", "FirstName", officeBearer.PersonId);
            return View(officeBearer);
        }

        // POST: OfficeBearers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RoleId,PersonId,StartDate,EndDate,Email")] OfficeBearer officeBearer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(officeBearer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RoleId = new SelectList(db.Roles, "RoleId", "Name", officeBearer.RoleId);
            ViewBag.PersonId = new SelectList(db.People, "PersonId", "FirstName", officeBearer.PersonId);
            return View(officeBearer);
        }

        // GET: OfficeBearers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OfficeBearer officeBearer = db.OfficeBearers.Find(id);
            if (officeBearer == null)
            {
                return HttpNotFound();
            }
            return View(officeBearer);
        }

        // POST: OfficeBearers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OfficeBearer officeBearer = db.OfficeBearers.Find(id);
            db.OfficeBearers.Remove(officeBearer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
