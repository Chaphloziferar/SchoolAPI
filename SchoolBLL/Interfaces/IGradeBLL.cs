using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBLL.Interfaces
{
    public interface IGradeBLL
    {
        Task<List<Grade>> GetAllGrades();
        Task<Grade> GetGradeById(int gradeId);
        Task<int> CreateGrade(int enrollmentId, Decimal grade);
        Task<int> UpdateGrade(int gradeId, int enrollmentId, Decimal grade);
        Task<int> DeleteGrade(int gradeId, string deletedDate);
    }
}
