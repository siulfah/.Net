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
    public class KelolaPenggunaController : Controller
    {
        private raihMimpiEntities1 db = new raihMimpiEntities1();

        // GET: KelolaPengguna
        public ActionResult Index()
        {
            var user = (LOGIN)Session["penggunaAktif"];
            if (user == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                var pENGGUNA = db.PENGGUNA.Include(p => p.PENCAIRANDANA);
                return View(pENGGUNA.ToList());
            }
        }

        // GET: KelolaPengguna/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PENGGUNA pENGGUNA = db.PENGGUNA.Find(id);
            if (pENGGUNA == null)
            {
                return HttpNotFound();
            }
            return View(pENGGUNA);
        }

        // GET: KelolaPengguna/Create
        public ActionResult Create()
        {
            ViewBag.ID_PENGGUNA = new SelectList(db.PENCAIRANDANA, "ID_PENCAIRAN_DANA", "NAMA_KEGIATAN");
            return View();
        }

        // POST: KelolaPengguna/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_PENGGUNA,ID_LOGIN,NAMA,TELEPON,STATUS,KTP,BIOGRAFI,FOTO_PROFILE,VERIFIKASI,UPDATE_BY,UPDATE_DATE,CREATE_BY,CREATE_DATE,KETERANGAN")] PENGGUNA pENGGUNA)
        {
            if (ModelState.IsValid)
            {
                db.PENGGUNA.Add(pENGGUNA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_PENGGUNA = new SelectList(db.PENCAIRANDANA, "ID_PENCAIRAN_DANA", "NAMA_KEGIATAN", pENGGUNA.ID_PENGGUNA);
            return View(pENGGUNA);
        }

        // GET: KelolaPengguna/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PENGGUNA pENGGUNA = db.PENGGUNA.Find(id);
            if (pENGGUNA == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_PENGGUNA = new SelectList(db.PENCAIRANDANA, "ID_PENCAIRAN_DANA", "NAMA_KEGIATAN", pENGGUNA.ID_PENGGUNA);
            return View(pENGGUNA);
        }

        // POST: KelolaPengguna/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_PENGGUNA,ID_LOGIN,NAMA,TELEPON,STATUS,KTP,BIOGRAFI,FOTO_PROFILE,VERIFIKASI,UPDATE_BY,UPDATE_DATE,CREATE_BY,CREATE_DATE,KETERANGAN")] PENGGUNA pENGGUNA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pENGGUNA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_PENGGUNA = new SelectList(db.PENCAIRANDANA, "ID_PENCAIRAN_DANA", "NAMA_KEGIATAN", pENGGUNA.ID_PENGGUNA);
            return View(pENGGUNA);
        }

        // GET: KelolaPengguna/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PENGGUNA pENGGUNA = db.PENGGUNA.Find(id);
            if (pENGGUNA == null)
            {
                return HttpNotFound();
            }
            //return View(pENGGUNA);
            PENGGUNA pengguna = db.PENGGUNA.Find(id);
            pengguna.STATUS = false;
            db.Entry(pengguna).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST: KelolaPengguna/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PENGGUNA pENGGUNA = db.PENGGUNA.Find(id);
            pENGGUNA.STATUS = false;
            db.Entry(pENGGUNA).State = EntityState.Modified;
            db.SaveChanges();
            //db.PENGGUNA.Remove(pENGGUNA);
            return RedirectToAction("Index");
        }

        public ActionResult Aktif(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PENGGUNA pengguna = db.PENGGUNA.Find(id);
            if (pengguna == null)
            {
                return HttpNotFound();
            }
            //return View(lOGIN);
            PENGGUNA Pengguna = db.PENGGUNA.Find(id);
            Pengguna.STATUS = true;
            db.Entry(Pengguna).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpPost, ActionName("Aktif")]
        [ValidateAntiForgeryToken]
        public ActionResult AktifConfirmed(int id)
        {
            PENGGUNA Pengguna = db.PENGGUNA.Find(id);
            Pengguna.STATUS = true;
            db.Entry(Pengguna).State = EntityState.Modified;
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
