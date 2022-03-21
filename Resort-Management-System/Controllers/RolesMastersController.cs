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
    public class RolesMastersController : Controller
    {
        private Resort_Management_DBEntities db = new Resort_Management_DBEntities();

        // GET: RolesMasters
        public ActionResult Index()
        {
            return View(db.RolesMasters.ToList());
        }

        // GET: RolesMasters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RolesMasters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RoleID,RoleName")] RolesMaster rolesMaster)
        {
            if (ModelState.IsValid)
            {
                db.RolesMasters.Add(rolesMaster);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rolesMaster);
        }

        // GET: RolesMasters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RolesMaster rolesMaster = db.RolesMasters.Find(id);
            if (rolesMaster == null)
            {
                return HttpNotFound();
            }
            return View(rolesMaster);
        }

        // POST: RolesMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RolesMaster rolesMaster = db.RolesMasters.Find(id);
            db.RolesMasters.Remove(rolesMaster);
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
