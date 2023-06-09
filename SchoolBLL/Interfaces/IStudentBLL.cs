using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBLL.Interfaces
{
    public interface IStudentBLL
    {
        Task<List<Student>> GetAllStudents();
        Task<Student> GetStudentById(int studentId);
        Task<int> CreateStudent(string fistName, string lastName, DateTime birthday, string address, string phoneNumber, string email);
        Task<int> UpdateStudent(int studentId, string fistName, string lastName, DateTime birthday, string address, string phoneNumber, string email);
        Task<int> DeleteStudent(int studentId, string deletedDate);
    }
}
