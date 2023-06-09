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
    public class TeacherBLL : ITeacherBLL
    {
        private readonly IConfiguration _configuration;
        private readonly TeacherDAL dbTeacher;
        public TeacherBLL(IConfiguration configuration)
        {
            _configuration = configuration;
            string connectionString = _configuration.GetConnectionString(name: "DefaultConnectionString");
            dbTeacher = new TeacherDAL(connectionString);
        }

        public async Task<List<Teacher>> GetAllTeachers()
        {
            return dbTeacher.GetAllTeachers();
        }

        public async Task<Teacher> GetTeacherById(int teacherId)
        {
            return await dbTeacher.GetTeacherById(teacherId);
        }

        public async Task<int> CreateTeacher(string fistName, string lastName, DateTime birthday, string address, string phoneNumber, string email)
        {
            return await dbTeacher.CreateTeacher(fistName, lastName, birthday, address, phoneNumber, email);
        }

        public async Task<int> UpdateTeacher(int teacherId, string fistName, string lastName, DateTime birthday, string address, string phoneNumber, string email)
        {
            return await dbTeacher.UpdateTeacher(teacherId, fistName, lastName, birthday, address, phoneNumber, email);
        }

        public async Task<int> DeleteTeacher(int teacherId, string deletedDate)
        {
            return await dbTeacher.DeleteTeacher(teacherId, deletedDate);
        }
    }
}
