using FormsEngine.Serialization;
using Newtonsoft.Json;
using System;

namespace FormsEngine.Models
{
    public class FormData
    {
        [JsonConverter(typeof(FormConverter))]
        public int Id { get; set; }
        public int Subject { get; set; }
        public int Submitter { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ProcedureDate { get; set; }
        public string TheData { get; set; }

        public virtual Form Form { get; set; }
    }
}
