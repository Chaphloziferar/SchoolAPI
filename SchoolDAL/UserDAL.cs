using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolDAL
{
    public class UserDAL : SchoolBaseDAL
    {
        public UserDAL(string connectionString) : base(connectionString)
        {
        }

        public List<User> GetAllUsers()
        {
            SqlConnection connection = GetConnection();
            connection.Open();
            SqlCommand command = new()
            {
                Connection = connection,
                CommandText = "SP_GetAllUsers",
                CommandType = CommandType.StoredProcedure
            };

            DataTable dt = new();
            SqlDataAdapter adapter = new(command);
            adapter.Fill(dt);

            var query = dt.AsEnumerable().Select(x => new User
            {
                UserId = Convert.ToInt32(x["user_id"]),
                Username = Convert.ToString(x["username"]),
                Password = Convert.ToString(x["password"]),
                UserType = Convert.ToString(x["user_type"]),
                DeletedDate = x["deleted_date"] != DBNull.Value ? Convert.ToDateTime(x["deleted_date"]) : null
            });

            return query.ToList();
        }
        
        public async Task<User> GetUserById(int userId)
        {
            SqlConnection connection = GetConnection();
            connection.Open();
            SqlCommand command = new()
            {
                Connection = connection,
                CommandText = "SP_GetUserById",
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@pUserId", userId);

            SqlDataReader reader = await command.ExecuteReaderAsync();
            User user = new();
            if(reader.Read())
            {
                user.UserId = Convert.ToInt32(reader["user_id"]);
                user.Username = Convert.ToString(reader["username"]);
                user.Password = Convert.ToString(reader["password"]);
                user.UserType = Convert.ToString(reader["user_type"]);
                user.DeletedDate = reader["deleted_date"] != DBNull.Value ? Convert.ToDateTime(reader["deleted_date"]) : null;
            }

            return user;
        }

        public async Task<int> CreateUser(string username, string password, string userType)
        {
            SqlConnection connection = GetConnection();
            connection.Open();
            SqlCommand command = new()
            {
                Connection = connection,
                CommandText = "SP_CreateUser",
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@pUsername", username);
            command.Parameters.AddWithValue("@pPassword", password);
            command.Parameters.AddWithValue("@pUserType", userType);

            return await command.ExecuteNonQueryAsync();
        }

        public async Task<int> UpdateUserType(int userId, string userType)
        {
            SqlConnection connection = GetConnection();
            connection.Open();
            SqlCommand command = new()
            {
                Connection = connection,
                CommandText = "SP_UpdateUserType",
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@pUserId", userId);
            command.Parameters.AddWithValue("@pUserType", userType);

            return await command.ExecuteNonQueryAsync();
        }

        public async Task<int> DeleteUser(int userId, string deletedDate)
        {
            SqlConnection connection = GetConnection();
            connection.Open();
            SqlCommand command = new()
            {
                Connection = connection,
                CommandText = "SP_DeleteUser",
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@pUserId", userId);
            command.Parameters.AddWithValue("@pDeletedDate", deletedDate);

            return await command.ExecuteNonQueryAsync();
        }
    }
}
