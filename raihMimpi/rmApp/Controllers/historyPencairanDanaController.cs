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
    public class historyPencairanDanaController : Controller
    {
        private raihMimpiEntities db = new raihMimpiEntities();

        // GET: historyPencairanDana
        public ActionResult Index()
        {
            var pENCAIRANDANA = db.PENCAIRANDANA.Include(p => p.PENGGUNA).Include(p => p.PROJEK);
            return View(pENCAIRANDANA.ToList());
        }

        // GET: historyPencairanDana/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PENCAIRANDANA pENCAIRANDANA = db.PENCAIRANDANA.Find(id);
            if (pENCAIRANDANA == null)
            {
                return HttpNotFound();
            }
            return View(pENCAIRANDANA);
        }

        // GET: historyPencairanDana/Create
        public ActionResult Create()
        {
            ViewBag.ID_PENCAIRAN_DANA = new SelectList(db.PENGGUNA, "ID_PENGGUNA", "NAMA");
            ViewBag.ID_PROYEK = new SelectList(db.PROJEK, "ID_PROYEK", "NAMA_PROYEK");
            return View();
        }

        // POST: historyPencairanDana/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_PENCAIRAN_DANA,ID_PROYEK,ID_PENGGUNA,NAMA_KEGIATAN,JUMLAH,NAMA_PENCAIR,NO_REKENING,STATUS,CREATE_BY,CREATE_DATE,UPDATE_BY,UPDATE_DATE,KETERANGAN")] PENCAIRANDANA pENCAIRANDANA)
        {
            if (ModelState.IsValid)
            {
                db.PENCAIRANDANA.Add(pENCAIRANDANA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_PENCAIRAN_DANA = new SelectList(db.PENGGUNA, "ID_PENGGUNA", "NAMA", pENCAIRANDANA.ID_PENCAIRAN_DANA);
            ViewBag.ID_PROYEK = new SelectList(db.PROJEK, "ID_PROYEK", "NAMA_PROYEK", pENCAIRANDANA.ID_PROYEK);
            return View(pENCAIRANDANA);
        }

        // GET: historyPencairanDana/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PENCAIRANDANA pENCAIRANDANA = db.PENCAIRANDANA.Find(id);
            if (pENCAIRANDANA == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_PENCAIRAN_DANA = new SelectList(db.PENGGUNA, "ID_PENGGUNA", "NAMA", pENCAIRANDANA.ID_PENCAIRAN_DANA);
            ViewBag.ID_PROYEK = new SelectList(db.PROJEK, "ID_PROYEK", "NAMA_PROYEK", pENCAIRANDANA.ID_PROYEK);
            return View(pENCAIRANDANA);
        }

        // POST: historyPencairanDana/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_PENCAIRAN_DANA,ID_PROYEK,ID_PENGGUNA,NAMA_KEGIATAN,JUMLAH,NAMA_PENCAIR,NO_REKENING,STATUS,CREATE_BY,CREATE_DATE,UPDATE_BY,UPDATE_DATE,KETERANGAN")] PENCAIRANDANA pENCAIRANDANA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pENCAIRANDANA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_PENCAIRAN_DANA = new SelectList(db.PENGGUNA, "ID_PENGGUNA", "NAMA", pENCAIRANDANA.ID_PENCAIRAN_DANA);
            ViewBag.ID_PROYEK = new SelectList(db.PROJEK, "ID_PROYEK", "NAMA_PROYEK", pENCAIRANDANA.ID_PROYEK);
            return View(pENCAIRANDANA);
        }

        // GET: historyPencairanDana/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PENCAIRANDANA pENCAIRANDANA = db.PENCAIRANDANA.Find(id);
            if (pENCAIRANDANA == null)
            {
                return HttpNotFound();
            }
            return View(pENCAIRANDANA);
        }

        // POST: historyPencairanDana/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PENCAIRANDANA pENCAIRANDANA = db.PENCAIRANDANA.Find(id);
            db.PENCAIRANDANA.Remove(pENCAIRANDANA);
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
