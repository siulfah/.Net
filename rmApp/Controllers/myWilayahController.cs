﻿using rmApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace rmApp.Controllers
{
    public class myWilayahController : ApiController
    {
        private raihMimpiEntities1 db = new raihMimpiEntities1();

        public List<WILAYAH> Get()
        {
            var wilayah = from wil in db.WILAYAH
                        select wil;
            return wilayah.ToList();
        }
        // GET api/<controller>
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

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