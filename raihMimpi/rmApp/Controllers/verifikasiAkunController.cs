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
    public class verifikasiAkunController : Controller
    {
        private raihMimpiEntities db = new raihMimpiEntities();

        // GET: verifikasiAkun
        public ActionResult Index()
        {
            var lOGIN = db.LOGIN.Include(l => l.PERAN);
            return View(lOGIN.ToList());
        }

        // GET: verifikasiAkun/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOGIN lOGIN = db.LOGIN.Find(id);
            if (lOGIN == null)
            {
                return HttpNotFound();
            }
            return View(lOGIN);
        }

        // GET: verifikasiAkun/Create
        public ActionResult Create()
        {
            ViewBag.ID_PERAN = new SelectList(db.PERAN, "ID_PERAN", "PERAN1");
            return View();
        }

        // POST: verifikasiAkun/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_LOGIN,ID_PERAN,USERNAME,EMAIL,PASSWORD,STATUS,CREATE_BY,CREATE_DATE,UPDATE_BY,UPDATE_DATE,KETERANGAN")] LOGIN lOGIN)
        {
            if (ModelState.IsValid)
            {
                db.LOGIN.Add(lOGIN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_PERAN = new SelectList(db.PERAN, "ID_PERAN", "PERAN1", lOGIN.ID_PERAN);
            return View(lOGIN);
        }

        // GET: verifikasiAkun/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOGIN lOGIN = db.LOGIN.Find(id);
            if (lOGIN == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_PERAN = new SelectList(db.PERAN, "ID_PERAN", "PERAN1", lOGIN.ID_PERAN);
            return View(lOGIN);
        }

        // POST: verifikasiAkun/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_LOGIN,ID_PERAN,USERNAME,EMAIL,PASSWORD,STATUS,CREATE_BY,CREATE_DATE,UPDATE_BY,UPDATE_DATE,KETERANGAN")] LOGIN lOGIN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lOGIN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_PERAN = new SelectList(db.PERAN, "ID_PERAN", "PERAN1", lOGIN.ID_PERAN);
            return View(lOGIN);
        }

        // GET: verifikasiAkun/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOGIN lOGIN = db.LOGIN.Find(id);
            if (lOGIN == null)
            {
                return HttpNotFound();
            }
            //return View(lOGIN);
            LOGIN login = db.LOGIN.Find(id);
            login.STATUS = false;
            db.Entry(login).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST: verifikasiAkun/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LOGIN lOGIN = db.LOGIN.Find(id);
            lOGIN.STATUS = false;
            db.Entry(lOGIN).State = EntityState.Modified;
            db.SaveChanges();
            //db.LOGIN.Remove(lOGIN);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Aktif(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOGIN lOGIN = db.LOGIN.Find(id);
            if (lOGIN == null)
            {
                return HttpNotFound();
            }
            //return View(lOGIN);
            LOGIN login = db.LOGIN.Find(id);
            login.STATUS = true;
            db.Entry(login).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpPost, ActionName("Aktif")]
        [ValidateAntiForgeryToken]
        public ActionResult AktifConfirmed(int id)
        {
            LOGIN lOGIN = db.LOGIN.Find(id);
            lOGIN.STATUS = true;
            db.Entry(lOGIN).State = EntityState.Modified;
            db.SaveChanges();
            //db.LOGIN.Remove(lOGIN);
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
