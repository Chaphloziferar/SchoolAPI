using Entities;
using Microsoft.Extensions.Configuration;
using SchoolBLL.Interfaces;
using SchoolDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBLL.Implementations
{
    public class EnrollmentBLL : IEnrollmentBLL
    {
        private readonly IConfiguration _configuration;
        private readonly EnrollmentDAL dbEnrollment;
        public EnrollmentBLL(IConfiguration configuration)
        {
            _configuration = configuration;
            string connectionString = _configuration.GetConnectionString(name: "DefaultConnectionString");
            dbEnrollment = new EnrollmentDAL(connectionString);
        }

        public async Task<List<Enrollment>> GetAllEnrollments()
        {
            return dbEnrollment.GetAllEnrollments();
        }

        public async Task<Enrollment> GetEnrollmentById(int enrollmentId)
        {
            return await dbEnrollment.GetEnrollmentById(enrollmentId);
        }

        public async Task<int> CreateEnrollment(int studentId, int classId, DateTime enrollmentDate)
        {
            return await dbEnrollment.CreateEnrollment(studentId, classId, enrollmentDate);
        }

        public async Task<int> UpdateEnrollment(int enrollmentId, int studentId, int classId, DateTime enrollmentDate)
        {
            return await dbEnrollment.UpdateEnrollment(enrollmentId, studentId, classId, enrollmentDate);
        }

        public async Task<int> DeleteEnrollment(int enrollmentId, string deletedDate)
        {
            return await dbEnrollment.DeleteEnrollment(enrollmentId, deletedDate);
        }
    }
}
