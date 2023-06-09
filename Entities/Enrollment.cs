using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Enrollment
    {
        public int EnrollmentId { get; set; }
        public int StudentId { get; set; }
        public int ClassId { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
