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
    public class CustomerTransController : Controller
    {
        private Resort_Management_DBEntities db = new Resort_Management_DBEntities();

        // GET: CustomerTrans
        public ActionResult Index()
        {
            if ((string)Session["roleName"] != "Receptionist") {
                return RedirectToAction("Index", "EmployeeMasters");
            }
            var customerTrans = db.CustomerTrans.Include(c => c.AmenitiesMaster).Include(c => c.EmployeeMaster).Include(c => c.RoomMaster);
            return View(customerTrans.ToList());
        }

        // GET: CustomerTrans/Create
        public ActionResult Create()
        {
            if ((string)Session["roleName"] != "Receptionist")
            {
                return RedirectToAction("Index", "EmployeeMasters");
            }

            ViewBag.LuxuryProvided = new SelectList(db.AmenitiesMasters, "AmenityID", "AmenityName");
            ViewBag.HostEmployee = new SelectList(db.EmployeeMasters, "EmployeeID", "EmployeeName");
            ViewBag.RoomNumber = new SelectList(db.RoomMasters, "RoomNumber", "RoomType");
            return View();
        }

        // POST: CustomerTrans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BookingID,CustomerName,Age,Email,IdentityProof,Contact,Address,HostEmployee,RoomNumber,LuxuryProvided,CheckInDate,CheckOutDate,PaymentStatus,TotalPayment")] CustomerTran customerTran)
        {
            if ((string)Session["roleName"] != "Receptionist")
            {
                return RedirectToAction("Index", "EmployeeMasters");
            }

            if (ModelState.IsValid)
            {
                db.CustomerTrans.Add(customerTran);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LuxuryProvided = new SelectList(db.AmenitiesMasters, "AmenityID", "AmenityName", customerTran.LuxuryProvided);
            ViewBag.HostEmployee = new SelectList(db.EmployeeMasters, "EmployeeID", "EmployeeName", customerTran.HostEmployee);
            ViewBag.RoomNumber = new SelectList(db.RoomMasters, "RoomNumber", "RoomType", customerTran.RoomNumber);
            return View(customerTran);
        }

        // GET: CustomerTrans/Edit/5
        public ActionResult Edit(int? id)
        {
            if ((string)Session["roleName"] != "Receptionist")
            {
                return RedirectToAction("Index", "EmployeeMasters");
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerTran customerTran = db.CustomerTrans.Find(id);
            if (customerTran == null)
            {
                return HttpNotFound();
            }
            ViewBag.LuxuryProvided = new SelectList(db.AmenitiesMasters, "AmenityID", "AmenityName", customerTran.LuxuryProvided);
            ViewBag.HostEmployee = new SelectList(db.EmployeeMasters, "EmployeeID", "EmployeeName", customerTran.HostEmployee);
            ViewBag.RoomNumber = new SelectList(db.RoomMasters, "RoomNumber", "RoomType", customerTran.RoomNumber);
            return View(customerTran);
        }

        // POST: CustomerTrans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookingID,CustomerName,Age,Email,IdentityProof,Contact,Address,HostEmployee,RoomNumber,LuxuryProvided,CheckInDate,CheckOutDate,PaymentStatus,TotalPayment")] CustomerTran customerTran)
        {
            if ((string)Session["roleName"] != "Receptionist")
            {
                return RedirectToAction("Index", "EmployeeMasters");
            }

            if (ModelState.IsValid)
            {
                db.Entry(customerTran).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LuxuryProvided = new SelectList(db.AmenitiesMasters, "AmenityID", "AmenityName", customerTran.LuxuryProvided);
            ViewBag.HostEmployee = new SelectList(db.EmployeeMasters, "EmployeeID", "EmployeeName", customerTran.HostEmployee);
            ViewBag.RoomNumber = new SelectList(db.RoomMasters, "RoomNumber", "RoomType", customerTran.RoomNumber);
            return View(customerTran);
        }

        // GET: CustomerTrans/Delete/5
        public ActionResult Delete(int? id)
        {
            if ((string)Session["roleName"] != "Receptionist")
            {
                return RedirectToAction("Index", "EmployeeMasters");
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerTran customerTran = db.CustomerTrans.Find(id);
            if (customerTran == null)
            {
                return HttpNotFound();
            }
            return View(customerTran);
        }

        // POST: CustomerTrans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if ((string)Session["roleName"] != "Receptionist")
            {
                return RedirectToAction("Index", "EmployeeMasters");
            }

            CustomerTran customerTran = db.CustomerTrans.Find(id);
            db.CustomerTrans.Remove(customerTran);
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
