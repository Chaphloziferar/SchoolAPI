using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBLL.Interfaces
{
    public interface IEnrollmentBLL
    {
        Task<List<Enrollment>> GetAllEnrollments();
        Task<Enrollment> GetEnrollmentById(int enrollmentId);
        Task<int> CreateEnrollment(int studentId, int classId, DateTime enrollmentDate);
        Task<int> UpdateEnrollment(int enrollmentId, int studentId, int classId, DateTime enrollmentDate);
        Task<int> DeleteEnrollment(int enrollmentId, string deletedDate);
    }
}
