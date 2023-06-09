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
    public class GradeBLL : IGradeBLL
    {
        private readonly IConfiguration _configuration;
        private readonly GradesDAL dbGrade;
        public GradeBLL(IConfiguration configuration)
        {
            _configuration = configuration;
            string connectionString = _configuration.GetConnectionString(name: "DefaultConnectionString");
            dbGrade = new GradesDAL(connectionString);
        }

        public async Task<List<Grade>> GetAllGrades()
        {
            return dbGrade.GetAllGrades();
        }

        public async Task<Grade> GetGradeById(int gradeId)
        {
            return await dbGrade.GetGradeById(gradeId);
        }

        public async Task<int> CreateGrade(int enrollmentId, decimal grade)
        {
            return await dbGrade.CreateGrade(enrollmentId, grade);
        }

        public async Task<int> UpdateGrade(int gradeId, int enrollmentId, decimal grade)
        {
            return await dbGrade.UpdateGrade(gradeId, enrollmentId, grade);
        }

        public async Task<int> DeleteGrade(int gradeId, string deletedDate)
        {
            return await dbGrade.DeleteGrade(gradeId, deletedDate);
        }
    }
}
