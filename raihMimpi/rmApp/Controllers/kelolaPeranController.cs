using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using rmApp.Models;

namespace rmApp.Controllers
{
    public class kelolaPeranController : Controller
    {
        private raihMimpiEntities db = new raihMimpiEntities();

        // GET: kelolaPeran
        public ActionResult Index()
        {
            return View(db.PERAN.ToList());
        }

        // GET: kelolaPeran/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PERAN pERAN = db.PERAN.Find(id);
            if (pERAN == null)
            {
                return HttpNotFound();
            }
            return View(pERAN);
        }

        // GET: kelolaPeran/Create
        public ActionResult Create()
        {
            return RedirectToAction("Index");
        }

        // POST: kelolaPeran/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_PERAN,PERAN1,CREATE_BY,CREATE_DATE,UPDATE_BY,UPDATE_DATE,KETERANGAN")] PERAN pERAN)
        {
            if (ModelState.IsValid)
            {
                pERAN.CREATE_DATE = DateTime.Now;
                db.PERAN.Add(pERAN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pERAN);
        }

        // GET: kelolaPeran/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PERAN pERAN = db.PERAN.Find(id);
            if (pERAN == null)
            {
                return HttpNotFound();
            }
            return View(pERAN);
        }

        // POST: kelolaPeran/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_PERAN,PERAN1,CREATE_BY,CREATE_DATE,UPDATE_BY,UPDATE_DATE,KETERANGAN")] PERAN pERAN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pERAN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pERAN);
        }

        // GET: kelolaPeran/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PERAN pERAN = db.PERAN.Find(id);
            if (pERAN == null)
            {
                return HttpNotFound();
            }
            return View(pERAN);
        }

        // POST: kelolaPeran/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PERAN pERAN = db.PERAN.Find(id);
            db.PERAN.Remove(pERAN);
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
