using rmApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace rmApp.Controllers
{
    public class myProyekController : ApiController
    {
        private raihMimpiEntities db = new raihMimpiEntities();

        public List<PROJEK> Get()
        {
            var projek = from pro in db.PROJEK
                         where pro.STATUS_PROYEK == true
                         select pro;
            return projek.ToList();
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