﻿using rmApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace rmApp.Controllers
{
    public class HeaderController : ApiController
    {
        private raihMimpiEntities1 db = new raihMimpiEntities1();
        

        public LOGIN Get()
        {
            var user = (LOGIN)HttpContext.Current.Session["penggunaAktif"];
            var notifikasi = from notif in db.NOTIFICATION
                             where notif.DATE > user.LAST_LOGIN
                             select notif;
            return user;
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}