using FormsEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FormsEngine.ApiController
{
    public class FormController : System.Web.Http.ApiController
    {
        private dbContext _db = new dbContext();

        // GET: api/Form
        public IEnumerable<string> Get()
        {
            var forms = from f in _db.Forms
                        orderby f.FormName
                        select f.FormName;

            return forms;
        }

        // GET: api/Form/5
        public string Get(int id)
        {
            var form = (from f in _db.Forms
                       where f.Id == id
                       select f.Schema).SingleOrDefault();

            return form;
        }

        // POST: api/Form
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Form/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Form/5
        public void Delete(int id)
        {
        }
    }
}
