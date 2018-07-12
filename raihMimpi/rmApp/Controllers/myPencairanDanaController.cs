using rmApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace rmApp.Controllers
{
    public class myPencairanDanaController : ApiController
    {
        private raihMimpiEntities db = new raihMimpiEntities();

        // GET api/<controller>
        public List<PENCAIRANDANA> Get()
        {
            var pencairanDana = from pd in db.PENCAIRANDANA
                                select pd;
            return pencairanDana.ToList();
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