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
    public class UserBLL : IUserBLL
    {
        private readonly IConfiguration _configuration;
        private readonly UserDAL dbUser;
        public UserBLL(IConfiguration configuration)
        {
            _configuration = configuration;
            string connectionString = _configuration.GetConnectionString(name: "DefaultConnectionString");
            dbUser = new UserDAL(connectionString);
        }

        public async Task<List<User>> GetAllUsers()
        {
            return dbUser.GetAllUsers();
        }

        public async Task<User> GetUserById(int userId)
        {
            return await dbUser.GetUserById(userId);
        }

        public async Task<int> CreateUser(string username, string password, string userType)
        {
            return await dbUser.CreateUser(username, password, userType);
        }

        public async Task<int> UpdateUserType(int userId, string userType)
        {
            return await dbUser.UpdateUserType(userId, userType);
        }

        public async Task<int> DeleteUser(int userId, string deletedDate)
        {
            return await dbUser.DeleteUser(userId, deletedDate);
        }
    }
}
