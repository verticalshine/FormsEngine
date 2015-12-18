using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormsEngine.Models
{
    public class FormData
    {
        public int Id { get; set; }
        public int Subject { get; set; }
        public int Submitter { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ProcedureDate { get; set; }
        public string TheData { get; set; }

        public virtual Form Form { get; set; }
    }
}
