using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Grade
    {
        public int GradeId { get; set; }
        public int EnrollmentId { get; set; }
        public Decimal GradeValue { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
