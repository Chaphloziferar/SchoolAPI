using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBLL.Interfaces
{
    public interface IClassBLL
    {
        Task<List<Class>> GetAllClasses();
        Task<Class> GetClassById(int classId);
        Task<int> CreateClass(string className, int teacherId);
        Task<int> UpdateClass(int classId, string className, int teacherId);
        Task<int> DeleteClass(int classId, string deletedDate);
    }
}
