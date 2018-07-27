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
    public class KelolaWilayahController : Controller
    {
        private raihMimpiEntities1 db = new raihMimpiEntities1();

        // GET: KelolaWilayah
        public ActionResult Index()
        {
            var user = (LOGIN)Session["penggunaAktif"];
            if (user == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                return View(db.WILAYAH.ToList());
            }
        }
        
        [HttpPost]
        public ActionResult Index(string[] dynamicField, [Bind(Include = "ID_WILAYAH,NAMA_WILAYAH,CREATE_BY,CREATE_DATE,UPDATE_BY,UPDATE_DATE,KETERANGAN")] WILAYAH wILAYAH)
        {
            ViewBag.Data = string.Join(",", dynamicField ?? new string[] { });
            if (ModelState.IsValid)
            {
                db.WILAYAH.Add(wILAYAH);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
                
        // GET: KelolaWilayah/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WILAYAH wILAYAH = db.WILAYAH.Find(id);
            if (wILAYAH == null)
            {
                return HttpNotFound();
            }
            return View(wILAYAH);
        }

        // GET: KelolaWilayah/Create
        public ActionResult Create()
        {
            List<WILAYAH> wil = new List<WILAYAH> { new WILAYAH {NAMA_WILAYAH = ""} };
            return View(wil);
            //return RedirectToAction("Index");
        }

        // POST: KelolaWilayah/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create(string wilayahInput)
        //{
            //string[] part = wilayahInput.Split(',');
            //foreach (string a in part)
            //{
            //    if (ModelState.IsValid)
            //    {
            //        WILAYAH wilayah = new WILAYAH();
            //        wilayah.NAMA_WILAYAH = a;
            //        db.WILAYAH.Add(wilayah);
            //        db.SaveChanges();
            //        return RedirectToAction("Index");
            //    }
            //}
                        
        //    return View();
        //}
        public ActionResult Create(List<WILAYAH> wil)
        {
            if (ModelState.IsValid)
            {
                using (raihMimpiEntities1 db = new raihMimpiEntities1())
                {
                    foreach (var i in wil)
                    {
                        db.WILAYAH.Add(i);
                    }
                    db.SaveChanges();
                    ViewBag.Message = "Data Berhasil Disimpan";
                    ModelState.Clear();
                    wil = new List<WILAYAH> { new WILAYAH { NAMA_WILAYAH = "" } };
                }
            }
            return View(wil);
        }
        

        // GET: KelolaWilayah/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WILAYAH wILAYAH = db.WILAYAH.Find(id);
            if (wILAYAH == null)
            {
                return HttpNotFound();
            }
            return View(wILAYAH);
        }

        // POST: KelolaWilayah/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_WILAYAH,NAMA_WILAYAH,CREATE_BY,CREATE_DATE,UPDATE_BY,UPDATE_DATE,KETERANGAN")] WILAYAH wILAYAH)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wILAYAH).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(wILAYAH);
        }

        // GET: KelolaWilayah/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WILAYAH wILAYAH = db.WILAYAH.Find(id);
            if (wILAYAH == null)
            {
                return HttpNotFound();
            }
            WILAYAH wilayah = db.WILAYAH.Find(id);
            db.WILAYAH.Remove(wilayah);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST: KelolaWilayah/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WILAYAH wILAYAH = db.WILAYAH.Find(id);
            db.WILAYAH.Remove(wILAYAH);
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
