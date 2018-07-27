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
    public class KelolaKategoriController : Controller
    {
        private raihMimpiEntities1 db = new raihMimpiEntities1();

        // GET: KelolaKategori
        public ActionResult Index()
        {
            var user = (LOGIN)Session["penggunaAktif"];
            if (user == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                return View(db.KATEGORI.ToList());
            }
        }

        // GET: KelolaKategori/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KATEGORI kATEGORI = db.KATEGORI.Find(id);
            if (kATEGORI == null)
            {
                return HttpNotFound();
            }
            return View(kATEGORI);
        }

        // GET: KelolaKategori/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: KelolaKategori/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_KATEGORI,NAMA_KATEGORI,CREATE_BY,CREATE_DATE,UPDATE_BY,UPDATE_DATE,KETERANGAN")] KATEGORI kATEGORI)
        {
            if (ModelState.IsValid)
            {
                db.KATEGORI.Add(kATEGORI);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kATEGORI);
        }

        // GET: KelolaKategori/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KATEGORI kATEGORI = db.KATEGORI.Find(id);
            if (kATEGORI == null)
            {
                return HttpNotFound();
            }
            return View(kATEGORI);
        }

        // POST: KelolaKategori/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_KATEGORI,NAMA_KATEGORI,CREATE_BY,CREATE_DATE,UPDATE_BY,UPDATE_DATE,KETERANGAN")] KATEGORI kATEGORI)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kATEGORI).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kATEGORI);
        }

        // GET: KelolaKategori/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KATEGORI kATEGORI = db.KATEGORI.Find(id);
            if (kATEGORI == null)
            {
                return HttpNotFound();
            }
            return View(kATEGORI);
        }

        // POST: KelolaKategori/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KATEGORI kATEGORI = db.KATEGORI.Find(id);
            db.KATEGORI.Remove(kATEGORI);
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
