using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Class
    {
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public int TeacherId { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
