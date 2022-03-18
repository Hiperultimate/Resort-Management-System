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
    public class EmployeeMastersController : Controller
    {
        private Resort_Management_DBEntities db = new Resort_Management_DBEntities();

        // GET: EmployeeMasters
        public ActionResult Index()
        {
            var employeeMasters = db.EmployeeMasters.Include(e => e.RolesMaster);
            return View(employeeMasters.ToList());
        }

        public ActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// Login Function checks for correct email ID and password 
        /// then redirects to admin or receptionist page
        /// </summary>
        /// <param name="Login"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Login(FormCollection collection)
        {
            string email = collection.Get("email");
            string password = collection.Get("password");

            try
            {
                EmployeeMaster res = db.EmployeeMasters.Where(x => x.Email == email).First();
                if (email == res.Email && password == res.Password)
                {
                    RolesMaster role = db.RolesMasters.Where(x => x.RoleID == res.RoleID).First();
                    ViewBag.Message = role.RoleName;
                    if (role.RoleName == "Admin")
                    {
                        ViewBag.Message = "Admin";
                        //Response.Redirect("/ToAdminPage");
                    }
                    else if (role.RoleName == "Receptionist")
                    {
                        ViewBag.Message = "Receptionist";
                        //Response.Redirect("/ToReceptionistPage");
                    }
                }
            }
            catch
            {
                ViewBag.Message = "Please enter valid Email ID and Password";
            }

            return View();
        }

        // GET: EmployeeMasters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeMaster employeeMaster = db.EmployeeMasters.Find(id);
            if (employeeMaster == null)
            {
                return HttpNotFound();
            }
            return View(employeeMaster);
        }

        // GET: EmployeeMasters/Create
        public ActionResult Create()
        {
            ViewBag.RoleID = new SelectList(db.RolesMasters, "RoleID", "RoleName");
            return View();
        }

        // POST: EmployeeMasters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeID,EmployeeName,Email,Password,Address,Contact,RoleID,Salary")] EmployeeMaster employeeMaster)
        {
            if (ModelState.IsValid)
            {
                db.EmployeeMasters.Add(employeeMaster);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RoleID = new SelectList(db.RolesMasters, "RoleID", "RoleName", employeeMaster.RoleID);
            return View(employeeMaster);
        }

        // GET: EmployeeMasters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeMaster employeeMaster = db.EmployeeMasters.Find(id);
            if (employeeMaster == null)
            {
                return HttpNotFound();
            }
            ViewBag.RoleID = new SelectList(db.RolesMasters, "RoleID", "RoleName", employeeMaster.RoleID);
            return View(employeeMaster);
        }

        // POST: EmployeeMasters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeID,EmployeeName,Email,Password,Address,Contact,RoleID,Salary")] EmployeeMaster employeeMaster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeeMaster).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RoleID = new SelectList(db.RolesMasters, "RoleID", "RoleName", employeeMaster.RoleID);
            return View(employeeMaster);
        }

        // GET: EmployeeMasters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeMaster employeeMaster = db.EmployeeMasters.Find(id);
            if (employeeMaster == null)
            {
                return HttpNotFound();
            }
            return View(employeeMaster);
        }

        // POST: EmployeeMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmployeeMaster employeeMaster = db.EmployeeMasters.Find(id);
            db.EmployeeMasters.Remove(employeeMaster);
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
