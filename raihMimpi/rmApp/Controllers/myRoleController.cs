using rmApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace rmApp.Controllers
{
    public class myRoleController : ApiController
    {
        private raihMimpiEntities db = new raihMimpiEntities();

        public List<PERAN> Get()
        {
            var peran = from role in db.PERAN
                        select role;
            return peran.ToList();
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