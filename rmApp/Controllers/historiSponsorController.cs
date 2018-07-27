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
    public class historiSponsorController : Controller
    {
        private raihMimpiEntities1 db = new raihMimpiEntities1();

        // GET: historiSponsor
        public ActionResult Index()
        {
            var user = (LOGIN)Session["penggunaAktif"];
            if (user == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                var sPONSOR = db.SPONSOR.Include(s => s.PENGGUNA).Include(s => s.PROJEK);
                return View(sPONSOR.ToList());
            }
        }

        // GET: historiSponsor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SPONSOR sPONSOR = db.SPONSOR.Find(id);
            if (sPONSOR == null)
            {
                return HttpNotFound();
            }
            return View(sPONSOR);
        }

        // GET: historiSponsor/Create
        public ActionResult Create()
        {
            ViewBag.ID_PENGGUNA = new SelectList(db.PENGGUNA, "ID_PENGGUNA", "NAMA");
            ViewBag.ID_PROYEK = new SelectList(db.PROJEK, "ID_PROYEK", "NAMA_PROYEK");
            return View();
        }

        // POST: historiSponsor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_SPONSOR,ID_PROYEK,ID_PENGGUNA,JUMLAH_SPONSOR,ID_BANK,CREATE_BY,CREATE_DATE,UPDATE_BY,UPDATE_DATE,ANONIM,KETERANGAN,STATUS")] SPONSOR sPONSOR)
        {
            if (ModelState.IsValid)
            {
                db.SPONSOR.Add(sPONSOR);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_PENGGUNA = new SelectList(db.PENGGUNA, "ID_PENGGUNA", "NAMA", sPONSOR.ID_PENGGUNA);
            ViewBag.ID_PROYEK = new SelectList(db.PROJEK, "ID_PROYEK", "NAMA_PROYEK", sPONSOR.ID_PROYEK);
            return View(sPONSOR);
        }

        // GET: historiSponsor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SPONSOR sPONSOR = db.SPONSOR.Find(id);
            if (sPONSOR == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_PENGGUNA = new SelectList(db.PENGGUNA, "ID_PENGGUNA", "NAMA", sPONSOR.ID_PENGGUNA);
            ViewBag.ID_PROYEK = new SelectList(db.PROJEK, "ID_PROYEK", "NAMA_PROYEK", sPONSOR.ID_PROYEK);
            return View(sPONSOR);
        }

        // POST: historiSponsor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_SPONSOR,ID_PROYEK,ID_PENGGUNA,JUMLAH_SPONSOR,ID_BANK,CREATE_BY,CREATE_DATE,UPDATE_BY,UPDATE_DATE,ANONIM,KETERANGAN,STATUS")] SPONSOR sPONSOR)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sPONSOR).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_PENGGUNA = new SelectList(db.PENGGUNA, "ID_PENGGUNA", "NAMA", sPONSOR.ID_PENGGUNA);
            ViewBag.ID_PROYEK = new SelectList(db.PROJEK, "ID_PROYEK", "NAMA_PROYEK", sPONSOR.ID_PROYEK);
            return View(sPONSOR);
        }

        // GET: historiSponsor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SPONSOR sPONSOR = db.SPONSOR.Find(id);
            if (sPONSOR == null)
            {
                return HttpNotFound();
            }
            return View(sPONSOR);
        }

        // POST: historiSponsor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SPONSOR sPONSOR = db.SPONSOR.Find(id);
            db.SPONSOR.Remove(sPONSOR);
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
