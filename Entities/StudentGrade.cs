using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class StudentGrade
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string StudentLastname { get; set; }
        public string ClassName { get; set; }
        public string TeacherName { get; set; }
        public string TeacherLastname { get; set; }
        public Decimal GradeValue { get; set; }
    }
}
