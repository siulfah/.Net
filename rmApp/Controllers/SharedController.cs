using rmApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace rmApp.Controllers
{
    public class SharedController : Controller
    {
        private raihMimpiEntities1 db = new raihMimpiEntities1();
        // GET: Shared
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult _Header()
        {
            var notif = new HttpClient();
            var response = notif.GetAsync("http://localhost:65067/api/Header").Result;
            var notification = response.Content.ReadAsAsync<List<NOTIFICATION>>().Result;
            return View(notification);

            //var lastLogin = from tgl in db.LOGIN
            //                select tgl.LAST_LOGIN;

            //var content = from cnt in db.NOTIFICATION
            //              select cnt.TABELREFERNSI;
            //ViewBag.contentNotif = content;

            //var type = from typ in db.NOTIFICATION
            //           select typ.TYPE;
            //ViewBag.typeNotif = type;

            //return View();
        }

    }
}