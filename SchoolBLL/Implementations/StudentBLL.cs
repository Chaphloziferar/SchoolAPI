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
    public class StudentBLL : IStudentBLL
    {
        private readonly IConfiguration _configuration;
        private readonly StudentDAL dbStudent;
        public StudentBLL(IConfiguration configuration)
        {
            _configuration = configuration;
            string connectionString = _configuration.GetConnectionString(name: "DefaultConnectionString");
            dbStudent = new StudentDAL(connectionString);
        }

        public async Task<List<Student>> GetAllStudents()
        {
            return dbStudent.GetAllStudents();
        }

        public async Task<Student> GetStudentById(int studentId)
        {
            return await dbStudent.GetStudentById(studentId);
        }

        public async Task<int> CreateStudent(string fistName, string lastName, DateTime birthday, string address, string phoneNumber, string email)
        {
            return await dbStudent.CreateStudent(fistName, lastName, birthday, address, phoneNumber, email);
        }
        public async Task<int> UpdateStudent(int studentId, string fistName, string lastName, DateTime birthday, string address, string phoneNumber, string email)
        {
            return await dbStudent.UpdateStudent(studentId, fistName, lastName, birthday, address,phoneNumber, email);
        }

        public async Task<int> DeleteStudent(int studentId, string deletedDate)
        {
            return await dbStudent.DeleteStudent(studentId, deletedDate);
        }
    }
}
