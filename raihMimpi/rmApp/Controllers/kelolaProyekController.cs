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
    public class kelolaProyekController : Controller
    {
        private raihMimpiEntities db = new raihMimpiEntities();

        // GET: kelolaProyek
        public ActionResult Index()
        {
            var pROJEK = db.PROJEK.Include(p => p.PENGGUNA).Include(p => p.WILAYAH);
            return View(pROJEK.ToList());
        }

        // GET: kelolaProyek/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PROJEK pROJEK = db.PROJEK.Find(id);
            if (pROJEK == null)
            {
                return HttpNotFound();
            }
            return View(pROJEK);
        }

        // GET: kelolaProyek/Create
        public ActionResult Create()
        {
            ViewBag.ID_PENGGUNA = new SelectList(db.PENGGUNA, "ID_PENGGUNA", "NAMA");
            ViewBag.ID_WILAYAH = new SelectList(db.WILAYAH, "ID_WILAYAH", "NAMA_WILAYAH");
            return View();
        }

        // POST: kelolaProyek/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_PROYEK,ID_PENGGUNA,ID_KATEGORI,ID_WILAYAH,NAMA_PROYEK,DESKRIPSI_SINGKAT,DESKRIPSI_LENGKAP,LINK,STATUS_PROYEK,TANGGAL_BERAKHIR,TARGET_DANA,FITUR,SUKA,CREATE_BY,CREATE_DATE,UPDATE_BY,UPDATE_DATE,KOMISI_FLAT,KOMISI_PERSEN,TOTAL_DANA,KETERANGAN")] PROJEK pROJEK)
        {
            if (ModelState.IsValid)
            {
                db.PROJEK.Add(pROJEK);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_PENGGUNA = new SelectList(db.PENGGUNA, "ID_PENGGUNA", "NAMA", pROJEK.ID_PENGGUNA);
            ViewBag.ID_WILAYAH = new SelectList(db.WILAYAH, "ID_WILAYAH", "NAMA_WILAYAH", pROJEK.ID_WILAYAH);
            return View(pROJEK);
        }

        // GET: kelolaProyek/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PROJEK pROJEK = db.PROJEK.Find(id);
            if (pROJEK == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_PENGGUNA = new SelectList(db.PENGGUNA, "ID_PENGGUNA", "NAMA", pROJEK.ID_PENGGUNA);
            ViewBag.ID_WILAYAH = new SelectList(db.WILAYAH, "ID_WILAYAH", "NAMA_WILAYAH", pROJEK.ID_WILAYAH);
            return View(pROJEK);
        }

        // POST: kelolaProyek/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_PROYEK,ID_PENGGUNA,ID_KATEGORI,ID_WILAYAH,NAMA_PROYEK,DESKRIPSI_SINGKAT,DESKRIPSI_LENGKAP,LINK,STATUS_PROYEK,TANGGAL_BERAKHIR,TARGET_DANA,FITUR,SUKA,CREATE_BY,CREATE_DATE,UPDATE_BY,UPDATE_DATE,KOMISI_FLAT,KOMISI_PERSEN,TOTAL_DANA,KETERANGAN")] PROJEK pROJEK)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pROJEK).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_PENGGUNA = new SelectList(db.PENGGUNA, "ID_PENGGUNA", "NAMA", pROJEK.ID_PENGGUNA);
            ViewBag.ID_WILAYAH = new SelectList(db.WILAYAH, "ID_WILAYAH", "NAMA_WILAYAH", pROJEK.ID_WILAYAH);
            return View(pROJEK);
        }

        // GET: kelolaProyek/Delete/5
        public ActionResult Delete(int? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //PROJEK pROJEK = db.PROJEK.Find(id);
            //if (pROJEK == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(pROJEK);
            PROJEK projek = db.PROJEK.Find(id);
            projek.STATUS_PROYEK = false;
            //db.PENGGUNA.Remove(pENGGUNA);
            db.Entry(projek).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST: kelolaProyek/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PROJEK pROJEK = db.PROJEK.Find(id);
            pROJEK.STATUS_PROYEK = false;
            //db.PROJEK.Remove(pROJEK);
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
