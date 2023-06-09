using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBLL.Interfaces
{
    public interface IUserBLL
    {
        Task<List<User>> GetAllUsers();
        Task<User> GetUserById(int userId);
        Task<int> CreateUser(string username, string password, string userType);
        Task<int> UpdateUserType(int userId, string userType);
        Task<int> DeleteUser(int userId, string deletedDate);
    }
}
