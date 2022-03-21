using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Resort_Management_System.Models;

namespace Resort_Management_System.Controllers
{
    [Authorize]
    public class FacilityAmenityTransController : Controller
    {
        private Resort_Management_DBEntities db = new Resort_Management_DBEntities();

        // GET: FacilityAmenityTrans
        public ActionResult Index()
        {
            var facilityAmenityTrans = db.FacilityAmenityTrans.Include(f => f.AmenitiesMaster);
            return View(facilityAmenityTrans.ToList());
        }

        // GET: FacilityAmenityTrans/Create
        public ActionResult Create()
        {
            ViewBag.AmenityID = new SelectList(db.AmenitiesMasters, "AmenityID", "AmenityName");
            return View();
        }

        // POST: FacilityAmenityTrans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LuxuryID,LuxuryName,AmenityID,LuxuryCost")] FacilityAmenityTran facilityAmenityTran)
        {
            if (ModelState.IsValid)
            {
                db.FacilityAmenityTrans.Add(facilityAmenityTran);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AmenityID = new SelectList(db.AmenitiesMasters, "AmenityID", "AmenityName", facilityAmenityTran.AmenityID);
            return View(facilityAmenityTran);
        }

        // GET: FacilityAmenityTrans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FacilityAmenityTran facilityAmenityTran = db.FacilityAmenityTrans.Find(id);
            if (facilityAmenityTran == null)
            {
                return HttpNotFound();
            }
            ViewBag.AmenityID = new SelectList(db.AmenitiesMasters, "AmenityID", "AmenityName", facilityAmenityTran.AmenityID);
            return View(facilityAmenityTran);
        }

        // POST: FacilityAmenityTrans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LuxuryID,LuxuryName,AmenityID,LuxuryCost")] FacilityAmenityTran facilityAmenityTran)
        {
            if (ModelState.IsValid)
            {
                db.Entry(facilityAmenityTran).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AmenityID = new SelectList(db.AmenitiesMasters, "AmenityID", "AmenityName", facilityAmenityTran.AmenityID);
            return View(facilityAmenityTran);
        }

        // GET: FacilityAmenityTrans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FacilityAmenityTran facilityAmenityTran = db.FacilityAmenityTrans.Find(id);
            if (facilityAmenityTran == null)
            {
                return HttpNotFound();
            }
            return View(facilityAmenityTran);
        }

        // POST: FacilityAmenityTrans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FacilityAmenityTran facilityAmenityTran = db.FacilityAmenityTrans.Find(id);
            db.FacilityAmenityTrans.Remove(facilityAmenityTran);
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
