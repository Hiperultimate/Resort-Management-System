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
    public class AmenitiesMastersController : Controller
    {
        private Resort_Management_DBEntities db = new Resort_Management_DBEntities();

        // GET: AmenitiesMasters
        public ActionResult Index()
        {
            return View(db.AmenitiesMasters.ToList());
        }

        // GET: AmenitiesMasters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AmenitiesMaster amenitiesMaster = db.AmenitiesMasters.Find(id);
            if (amenitiesMaster == null)
            {
                return HttpNotFound();
            }
            return View(amenitiesMaster);
        }

        // GET: AmenitiesMasters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AmenitiesMasters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AmenityID,AmenityName")] AmenitiesMaster amenitiesMaster)
        {
            if (ModelState.IsValid)
            {
                db.AmenitiesMasters.Add(amenitiesMaster);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(amenitiesMaster);
        }

        // GET: AmenitiesMasters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AmenitiesMaster amenitiesMaster = db.AmenitiesMasters.Find(id);
            if (amenitiesMaster == null)
            {
                return HttpNotFound();
            }
            return View(amenitiesMaster);
        }

        // POST: AmenitiesMasters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AmenityID,AmenityName")] AmenitiesMaster amenitiesMaster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(amenitiesMaster).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(amenitiesMaster);
        }

        // GET: AmenitiesMasters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AmenitiesMaster amenitiesMaster = db.AmenitiesMasters.Find(id);
            if (amenitiesMaster == null)
            {
                return HttpNotFound();
            }
            return View(amenitiesMaster);
        }

        // POST: AmenitiesMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AmenitiesMaster amenitiesMaster = db.AmenitiesMasters.Find(id);
            db.AmenitiesMasters.Remove(amenitiesMaster);
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
