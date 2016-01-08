using FormsEngine.Dtos;
using FormsEngine.Models;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace FormsEngine.ApiController
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class FormDataController : System.Web.Http.ApiController
    {
        private dbContext _db = new dbContext();

        // GET: api/FormData
        public IEnumerable<string> Get()
        {
            return new string[] { "No", "No", "No" };
        }

        // GET: api/FormData/5
        public FormDataOutDto Get(int id)
        {
            var formData = (from f in _db.FormData
                            where f.Id == id
                            select new { f.TheData, f.Form.Id }).SingleOrDefault();

            var formStructure = (from f in _db.Forms
                              where f.Id == formData.Id
                              select new { f.Schema, f.Options }).SingleOrDefault();

            FormDataOutDto dto = new FormDataOutDto() { FormData = formData.TheData, FormSchema = formStructure.Schema, FormOptions = formStructure.Options };

            return dto;
        }

        // POST: api/FormData
        public void Post([FromBody]string value)
        {
            //JSchema schema = JSchema.Parse(@"{
            //    'type': 'object',
            //    'properties': {
            //    'schemaId': '1',
            //    'name': {'type':'string'},
            //    'hobbies': {
            //            'type': 'array',
            //            'items': {'type':'string'}
            //                }
            //         }
            //    }");

            JObject form = JObject.Parse(@value);

            int schemaId = 0;

            try
            {
                schemaId = (int)form["schemaId"];
            }
            catch
            {
                //throw
            }

            var formSchema = JSchema.Parse((from f in _db.Forms
                              where f.Id == schemaId
                              select f.Schema).SingleOrDefault());

            IList<string> errorMessages;
            bool valid = form.IsValid(formSchema, out errorMessages);

            if (valid)
            {
                var formData = new FormData() { TheData = form.ToString() };
                _db.FormData.Add(formData);
                _db.SaveChanges();
            }
            else
            {
                // errors back to client
            }
        }

        // PUT: api/FormData/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/FormData/5
        public void Delete(int id)
        {
        }
    }
}
