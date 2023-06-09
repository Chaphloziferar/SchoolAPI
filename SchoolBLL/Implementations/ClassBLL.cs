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
    public class ClassBLL : IClassBLL
    {
        private readonly IConfiguration _configuration;
        private readonly ClassDAL dbClass;
        public ClassBLL(IConfiguration configuration)
        {
            _configuration = configuration;
            string connectionString = _configuration.GetConnectionString(name: "DefaultConnectionString");
            dbClass = new ClassDAL(connectionString);
        }

        public async Task<List<Class>> GetAllClasses()
        {
            return dbClass.GetAllClasses();
        }

        public async Task<Class> GetClassById(int classId)
        {
            return await dbClass.GetClassById(classId);
        }

        public async Task<int> CreateClass(string className, int teacherId)
        {
            return await dbClass.CreateClass(className, teacherId);
        }

        public async Task<int> UpdateClass(int classId, string className, int teacherId)
        {
            return await dbClass.UpdateClass(classId, className, teacherId);
        }

        public async Task<int> DeleteClass(int classId, string deletedDate)
        {
            return await dbClass.DeleteClass(classId, deletedDate);
        }
    }
}
