using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Resort_Management_System.Models;

namespace Resort_Management_System.Controllers
{
    public class EmployeeMastersController : Controller
    {
        private Resort_Management_DBEntities db = new Resort_Management_DBEntities();

        // GET: EmployeeMasters
        [Authorize]
        public ActionResult Index()
        {
            if ((string)Session["roleName"] != "Admin")
            {
                return RedirectToAction("Index", "CustomerTrans");
            }

            var employeeMasters = db.EmployeeMasters.Include(e => e.RolesMaster);
            return View(employeeMasters.ToList());
        }

        public ActionResult Login()
        {
            if (Session["roleName"] != null)
            {
                if ((string)Session["roleName"] == "Admin")
                {
                    return RedirectToAction("Index", "EmployeeMasters");
                }
                else
                {
                    return RedirectToAction("Index", "CustomerTrans");
                }
            }
            return View();
        }

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
                    Session["roleName"] = role.RoleName;

                    if (role.RoleName == "Admin")
                    {
                        FormsAuthentication.SetAuthCookie(res.EmployeeName, false);
                        //this will redirect to the index action of Employeemaster controller if the role name is found to be admin.
                        Response.Redirect("Index");
                    }
                    else if (role.RoleName == "Receptionist")
                    {
                        FormsAuthentication.SetAuthCookie(res.EmployeeName, false);
                        //this will redirect to index action method of CustomerTrans controller if the role name is found to be receptionist.
                        return RedirectToAction("Index", "CustomerTrans");

                    }
                }
            }
            catch
            {
                ViewBag.Message = "Please enter valid Email ID and Password";
            }

            return View();
        }

        public ActionResult Logout() {
            Session["roleName"] = null;
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "EmployeeMasters");
        }

        // GET: EmployeeMasters/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if ((string)Session["roleName"] != "Admin")
            {
                return RedirectToAction("Index", "CustomerTrans");
            }

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
        [Authorize]
        public ActionResult Create()
        {
            if ((string)Session["roleName"] != "Admin")
            {
                return RedirectToAction("Index", "CustomerTrans");
            }

            ViewBag.RoleID = new SelectList(db.RolesMasters, "RoleID", "RoleName");
            return View();
        }

        // POST: EmployeeMasters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeID,EmployeeName,Email,Password,Address,Contact,RoleID,Salary")] EmployeeMaster employeeMaster)
        {
            if ((string)Session["roleName"] != "Admin")
            {
                return RedirectToAction("Index", "CustomerTrans");
            }

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
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if ((string)Session["roleName"] != "Admin")
            {
                return RedirectToAction("Index", "CustomerTrans");
            }

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
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeID,EmployeeName,Email,Password,Address,Contact,RoleID,Salary")] EmployeeMaster employeeMaster)
        {
            if ((string)Session["roleName"] != "Admin")
            {
                return RedirectToAction("Index", "CustomerTrans");
            }

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
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if ((string)Session["roleName"] != "Admin")
            {
                return RedirectToAction("Index", "CustomerTrans");
            }

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
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if ((string)Session["roleName"] != "Admin")
            {
                return RedirectToAction("Index", "CustomerTrans");
            }

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
