using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MemberManager.Models;
using System.Web.SessionState;

namespace MemberManager.Controllers
{
    [Authorize]
    [SessionState(SessionStateBehavior.Required)]
    public class CompsController : Controller
    {
        private tbawaEntities db = new tbawaEntities();

        // GET: Comps
        public ActionResult Index()
        {
            var comps = db.Comps.Include(c => c.Club).Include(c => c.CompType).OrderByDescending(c => c.CompID);
            return View(comps.ToList());
        }

        // GET: Comps/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comp comp = db.Comps.Find(id);
            if (comp == null)
            {
                return HttpNotFound();
            }
            return View(comp);
        }

        // GET: Comps/Create
        public ActionResult Create()
        {
            ViewBag.HostClubID = new SelectList(db.Clubs, "ClubId", "Name");
            ViewBag.CompID = new SelectList(db.Comps, "CompID", "CompName");
            ViewBag.CompID = new SelectList(db.Comps, "CompID", "CompName");
            ViewBag.CompTypeID = new SelectList(db.CompTypes, "CompTypeID", "Name");
            return View();
        }

        // POST: Comps/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CompID,CompName,CompTypeID,HostClubID")] Comp comp)
        {
            if (ModelState.IsValid)
            {
                db.Comps.Add(comp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.HostClubID = new SelectList(db.Clubs, "ClubId", "Name", comp.HostClubID);
            ViewBag.CompID = new SelectList(db.Comps, "CompID", "CompName", comp.CompID);
            ViewBag.CompID = new SelectList(db.Comps, "CompID", "CompName", comp.CompID);
            ViewBag.CompTypeID = new SelectList(db.CompTypes, "CompTypeID", "Name", comp.CompTypeID);
            return View(comp);
        }

        // GET: Comps/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comp comp = db.Comps.Find(id);
            if (comp == null)
            {
                return HttpNotFound();
            }
            ViewBag.HostClubID = new SelectList(db.Clubs, "ClubId", "Name", comp.HostClubID);
            ViewBag.CompID = new SelectList(db.Comps, "CompID", "CompName", comp.CompID);
            ViewBag.CompID = new SelectList(db.Comps, "CompID", "CompName", comp.CompID);
            ViewBag.CompTypeID = new SelectList(db.CompTypes, "CompTypeID", "Name", comp.CompTypeID);
            return View(comp);
        }

        // POST: Comps/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CompID,CompName,CompTypeID,HostClubID")] Comp comp)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comp).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HostClubID = new SelectList(db.Clubs, "ClubId", "Name", comp.HostClubID);
            ViewBag.CompID = new SelectList(db.Comps, "CompID", "CompName", comp.CompID);
            ViewBag.CompID = new SelectList(db.Comps, "CompID", "CompName", comp.CompID);
            ViewBag.CompTypeID = new SelectList(db.CompTypes, "CompTypeID", "Name", comp.CompTypeID);
            return View(comp);
        }

        // GET: Comps/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comp comp = db.Comps.Find(id);
            if (comp == null)
            {
                return HttpNotFound();
            }
            return View(comp);
        }

        // POST: Comps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Comp comp = db.Comps.Find(id);
            db.Comps.Remove(comp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Comps/Manage/5
        public ActionResult Manage(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comp comp = db.Comps.Find(id);
            if (comp == null)
            {
                return HttpNotFound();
            }
            Session["CompName"] = comp.CompName;
            Session["CompID"] = comp.CompID;
            return RedirectToAction("Index", "Fixtures");
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
