using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBLL.Interfaces
{
    public interface ITeacherBLL
    {
        Task<List<Teacher>> GetAllTeachers();
        Task<Teacher> GetTeacherById(int teacherId);
        Task<int> CreateTeacher(string fistName, string lastName, DateTime birthday, string address, string phoneNumber, string email);
        Task<int> UpdateTeacher(int teacherId, string fistName, string lastName, DateTime birthday, string address, string phoneNumber, string email);
        Task<int> DeleteTeacher(int teacherId, string deletedDate);
    }
}
