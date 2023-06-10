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
    public class StudentGradeBLL : IStudentGradeBLL
    {
        private readonly IConfiguration _configuration;
        private readonly StudentGradeDAL dbStudentGrade;
        public StudentGradeBLL(IConfiguration configuration)
        {
            _configuration = configuration;
            string connectionString = _configuration.GetConnectionString(name: "DefaultConnectionString");
            dbStudentGrade = new StudentGradeDAL(connectionString);
        }

        public async Task<List<StudentGrade>> GetAllStudentsGradesById(int studentId)
        {
            return dbStudentGrade.GetAllStudentsGradesById(studentId);
        }
    }
}
