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
    public class FixturesController : Controller
    {
        private tbawaEntities db = new tbawaEntities();

        // GET: Fixtures
        public ActionResult Index()
        {
            int compID = (int)Session["CompID"];
            var compFixtures = db.CompFixtures.Where(c => c.CompID == compID).Include(c => c.Comp).Include(c => c.CompDiamond).Include(c => c.HomeTeam).Include(c => c.AwayTeam).Include(c => c.CompTimeSlot);
            return View(compFixtures.ToList());
        }

        // GET: Fixtures/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompFixture compFixture = db.CompFixtures.Find(id);
            if (compFixture == null)
            {
                return HttpNotFound();
            }
            return View(compFixture);
        }

        // GET: Fixtures/Create
        public ActionResult Create()
        {
            ViewBag.CompID = new SelectList(db.Comps, "CompID", "CompName");
            ViewBag.CompID = new SelectList(db.CompDiamonds, "CompID", "Name");
            ViewBag.AwayTeamID = new SelectList(db.CompTeams, "CompTeamID", "Name");
            ViewBag.HomeTeamID = new SelectList(db.CompTeams, "CompTeamID", "Name");
            ViewBag.CompID = new SelectList(db.CompTimeSlots, "CompID", "CompID");
            return View();
        }

        // POST: Fixtures/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CompID,TimeSlot,Diamond,Game,HomeTeamID,AwayTeamID,HomeTeamMatchCode,HomeTeamWinLoss,AwayTeamMatchCode,AwayTeamWinLoss,HomeTeamRuns,AwayTeamRuns,PlateUmpireNo,FirstBaseUmpireNo,SecondBaseUmpireNo")] CompFixture compFixture)
        {
            if (ModelState.IsValid)
            {
                db.CompFixtures.Add(compFixture);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CompID = new SelectList(db.Comps, "CompID", "CompName", compFixture.CompID);
            ViewBag.CompID = new SelectList(db.CompDiamonds, "CompID", "Name", compFixture.CompID);
            ViewBag.AwayTeamID = new SelectList(db.CompTeams, "CompTeamID", "Name", compFixture.AwayTeamID);
            ViewBag.HomeTeamID = new SelectList(db.CompTeams, "CompTeamID", "Name", compFixture.HomeTeamID);
            ViewBag.CompID = new SelectList(db.CompTimeSlots, "CompID", "CompID", compFixture.CompID);
            return View(compFixture);
        }

        // GET: Fixtures/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompFixture compFixture = db.CompFixtures.Find(id);
            if (compFixture == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompID = new SelectList(db.Comps, "CompID", "CompName", compFixture.CompID);
            ViewBag.CompID = new SelectList(db.CompDiamonds, "CompID", "Name", compFixture.CompID);
            ViewBag.AwayTeamID = new SelectList(db.CompTeams, "CompTeamID", "Name", compFixture.AwayTeamID);
            ViewBag.HomeTeamID = new SelectList(db.CompTeams, "CompTeamID", "Name", compFixture.HomeTeamID);
            ViewBag.CompID = new SelectList(db.CompTimeSlots, "CompID", "CompID", compFixture.CompID);
            return View(compFixture);
        }

        // POST: Fixtures/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CompID,TimeSlot,Diamond,Game,HomeTeamID,AwayTeamID,HomeTeamMatchCode,HomeTeamWinLoss,AwayTeamMatchCode,AwayTeamWinLoss,HomeTeamRuns,AwayTeamRuns,PlateUmpireNo,FirstBaseUmpireNo,SecondBaseUmpireNo")] CompFixture compFixture)
        {
            if (ModelState.IsValid)
            {
                db.Entry(compFixture).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CompID = new SelectList(db.Comps, "CompID", "CompName", compFixture.CompID);
            ViewBag.CompID = new SelectList(db.CompDiamonds, "CompID", "Name", compFixture.CompID);
            ViewBag.AwayTeamID = new SelectList(db.CompTeams, "CompTeamID", "Name", compFixture.AwayTeamID);
            ViewBag.HomeTeamID = new SelectList(db.CompTeams, "CompTeamID", "Name", compFixture.HomeTeamID);
            ViewBag.CompID = new SelectList(db.CompTimeSlots, "CompID", "CompID", compFixture.CompID);
            return View(compFixture);
        }

        // GET: Fixtures/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompFixture compFixture = db.CompFixtures.Find(id);
            if (compFixture == null)
            {
                return HttpNotFound();
            }
            return View(compFixture);
        }

        // POST: Fixtures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CompFixture compFixture = db.CompFixtures.Find(id);
            db.CompFixtures.Remove(compFixture);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Fixtures/Results/5
        public ActionResult Results(int? timeSlot)
        {
            int compID = (int)Session["CompID"];
            if (timeSlot == null)
            {
                timeSlot = 1;
            }
            var compFixtures = db.CompFixtures.Where(c => c.CompID == compID && c.TimeSlot == timeSlot).Include(c => c.Comp).Include(c => c.CompDiamond).Include(c => c.HomeTeam).Include(c => c.AwayTeam).Include(c => c.CompTimeSlot);
            ViewBag.TimeSlots = new SelectList(db.CompTimeSlots.Where(c => c.CompID == compID), "timeSlot", "startTime");
            ViewBag.TimeSlot = timeSlot.ToString();
            return View(compFixtures.ToList());
        }

        // POST: Fixtures/Results
        [HttpPost, ActionName("Results")]
        public ActionResult ResultsSave(int timeSlot, List<CompFixture> fixtures)
        {
            foreach (CompFixture fixture in fixtures)
            {
                CompFixture compFixture = db.CompFixtures.Find(fixture.CompID, fixture.TimeSlot, fixture.Diamond);
                compFixture.HomeTeamRuns = fixture.HomeTeamRuns;
                compFixture.AwayTeamRuns = fixture.AwayTeamRuns;
                db.Entry(compFixture).State = EntityState.Modified;
            }
            db.SaveChanges();
            return Results(timeSlot);
        }

        // GET: Fixtures/Finals/5
        public ActionResult Finals(int? timeSlot)
        {
            int compID = (int)Session["CompID"];
            if (timeSlot == null || (timeSlot != 4 && timeSlot != 8))
            {
                timeSlot = 4;
            }
            List<CompFixture> fixtures = new List<CompFixture>();
            foreach (CalculateFinalRoundFixtures_Lightning finalFixture in db.CalculateFinalRoundFixtures_Lightning.Where(c => c.CompID == compID && c.TimeSlot == timeSlot).ToList())
            {
                CompFixture compFixture = new CompFixture();
                compFixture.CompID = (int)finalFixture.CompID;
                compFixture.TimeSlot = finalFixture.TimeSlot;
                compFixture.Diamond = finalFixture.Diamond;
                compFixture.Game = finalFixture.Game;
                compFixture.HomeTeamID = finalFixture.HomeTeamID;
                compFixture.AwayTeamID = finalFixture.AwayTeamID;
                compFixture.Comp = db.Comps.Find(compFixture.CompID);
                compFixture.CompTimeSlot = db.CompTimeSlots.Find(compFixture.CompID, compFixture.TimeSlot);
                compFixture.CompDiamond = db.CompDiamonds.Find(compFixture.CompID, compFixture.Diamond);
                compFixture.HomeTeam = db.CompTeams.Find(compFixture.HomeTeamID);
                compFixture.AwayTeam = db.CompTeams.Find(compFixture.AwayTeamID);
                CompFixture existing = db.CompFixtures.Where(c => c.CompID == compID && c.TimeSlot == timeSlot && c.HomeTeamID == compFixture.HomeTeamID).SingleOrDefault();
                if (existing != null)
                {
                    compFixture.Diamond = existing.Diamond;
                }
                fixtures.Add(compFixture);
            }
            ViewBag.TimeSlots = new SelectList(db.CompTimeSlots.Where(c => c.CompID == compID && (c.TimeSlot == 4 || c.TimeSlot == 8)), "timeSlot", "startTime");
            ViewBag.TimeSlot = timeSlot.ToString();
            return View(fixtures);
        }

        // POST: Fixtures/Finals
        [HttpPost, ActionName("Finals")]
        public ActionResult FinalsSave(int timeSlot, List<CompFixture> fixtures)
        {
            foreach (CompFixture finalFixture in fixtures)
            {
                CompFixture compFixture = db.CompFixtures.Find(finalFixture.CompID, finalFixture.TimeSlot, finalFixture.Diamond);
                if (compFixture == null)
                {
                    compFixture = new CompFixture();
                    compFixture.CompID = finalFixture.CompID;
                    compFixture.TimeSlot = finalFixture.TimeSlot;
                    compFixture.Diamond = finalFixture.Diamond;
                    db.Entry(compFixture).State = EntityState.Added;
                }
                else
                {
                    db.Entry(compFixture).State = EntityState.Modified;
                }
                compFixture.Game = finalFixture.Game;
                compFixture.HomeTeamID = finalFixture.HomeTeamID;
                compFixture.AwayTeamID = finalFixture.AwayTeamID;
            }
            db.SaveChanges();
            return RedirectToAction("Finals");
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
