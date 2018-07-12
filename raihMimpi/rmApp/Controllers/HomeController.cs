using rmApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace rmApp.Controllers
{
    public class HomeController : Controller
    {

        private raihMimpiEntities db = new raihMimpiEntities();
        public ActionResult Index()
        {

            ViewBag.jumlahProjek = db.PROJEK.Count();

            var a = from pro in db.PROJEK
                    where pro.STATUS_PROYEK == true
                    select pro;
            var b = a.Count();
            ViewBag.jumlahProjekAktif = b;

            var s = from sponsor in db.SPONSOR
                    select sponsor.JUMLAH_SPONSOR;
            var sumsponsor = s.Sum();
            ViewBag.jumlahSponsor = sumsponsor;

            var sponsorTrue = from jml in db.SPONSOR
                                where jml.STATUS == true
                                select jml.JUMLAH_SPONSOR;
            var totalSponsor = sponsorTrue.Sum();
            var jumlahDanaCair = from jml_cair in db.PENCAIRANDANA
                                  where jml_cair.STATUS == true
                                  select jml_cair.JUMLAH;
            var totalPencairan = jumlahDanaCair.Sum();
            var total = totalSponsor - totalPencairan;
            ViewBag.jumlahPencairan = total;
            
            ViewBag.jumlahPengguna = db.PENGGUNA.Count();

            var pengguna = from pro in db.PENGGUNA
                           where pro.STATUS == true
                           select pro;
            var x = pengguna.Count();
            ViewBag.jumlahPenggunaAktif = x;

            return View();
        }

        public ActionResult LOGIN()
        {
            //this.User.Identity.Name
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LOGIN(ProsesLogin pl, string ReturnUrl = "")
        {
            using (db)
            {
                var user = db.LOGIN.Where(a => a.EMAIL.Equals(pl.Email) && a.PASSWORD.Equals(pl.Password)).FirstOrDefault();
                //logger.Debug(user.EMAIL);
                if (user != null)
                {
                    Session["penggunaAktif"] = user;
                    Session["peranAktif"] = user.PERAN;
                    //FormsAuthentication.SetAuthCookie(user.email);
                    if (Url.IsLocalUrl(ReturnUrl))
                    {
                        return Redirect(ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            ModelState.Remove("Password");
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}