using FormsEngine.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormsEngine.Models
{
    public class Form
    {
        public int Id { get; set; }
        public string FormName { get; set; }
        public int Version { get; set; }
        public string Schema { get; set; }

        public string Options { get; set; }

        public virtual ICollection<FormData> FormData { get; set; }
    }
}
