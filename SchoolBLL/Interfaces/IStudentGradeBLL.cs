using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBLL.Interfaces
{
    public interface IStudentGradeBLL
    {
        Task<List<StudentGrade>> GetAllStudentsGradesById(int studentId);
    }
}
