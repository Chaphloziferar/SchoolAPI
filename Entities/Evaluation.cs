using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Evaluation
    {
        public int EvaluationId { get; set; }
        public int EnrollmentId { get; set; }
        public DateTime EvaluationDate { get; set; }
        public string EvaluationType { get; set; }
        public decimal Score { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
