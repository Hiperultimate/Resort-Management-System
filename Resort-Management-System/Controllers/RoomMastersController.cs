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
    public class RoomMastersController : Controller
    {
        private Resort_Management_DBEntities db = new Resort_Management_DBEntities();

        // GET: RoomMasters
        public ActionResult Index()
        {
            return View(db.RoomMasters.ToList());
        }

        // GET: RoomMasters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoomMaster roomMaster = db.RoomMasters.Find(id);
            if (roomMaster == null)
            {
                return HttpNotFound();
            }
            return View(roomMaster);
        }

        // GET: RoomMasters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RoomMasters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RoomNumber,RoomType,IsOccupied,RoomCost")] RoomMaster roomMaster)
        {
            if (roomMaster.RoomNumber != 0) {
                try
                {
                    RoomMaster roomInfo = db.RoomMasters.Where(x => x.RoomNumber == roomMaster.RoomNumber).First();
                    if (roomInfo != null)
                    {
                        ViewBag.ErrorMsg = $"Error : Room number {roomMaster.RoomNumber} already exists. Please enter a new Room Number.";
                        return View(roomMaster);
                    }
                }
                catch (Exception ex) {
                    ViewBag.ErrorMsg = $"Room number is safe to use.";
                }
            }

            if (ModelState.IsValid)
            {
                if (roomMaster.RoomNumber == 0) {
                    ViewBag.ErrorMsg = $"Error : Please enter room number other than 0.";
                    return View(roomMaster);
                }
                db.RoomMasters.Add(roomMaster);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(roomMaster);
        }

        // GET: RoomMasters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoomMaster roomMaster = db.RoomMasters.Find(id);
            if (roomMaster == null)
            {
                return HttpNotFound();
            }
            return View(roomMaster);
        }

        // POST: RoomMasters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RoomNumber,RoomType,IsOccupied,RoomCost")] RoomMaster roomMaster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(roomMaster).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(roomMaster);
        }

        // GET: RoomMasters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoomMaster roomMaster = db.RoomMasters.Find(id);
            if (roomMaster == null)
            {
                return HttpNotFound();
            }
            return View(roomMaster);
        }

        // POST: RoomMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RoomMaster roomMaster = db.RoomMasters.Find(id);
            db.RoomMasters.Remove(roomMaster);
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
