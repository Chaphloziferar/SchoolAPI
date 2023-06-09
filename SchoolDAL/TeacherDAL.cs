using Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolDAL
{
    public class TeacherDAL : SchoolBaseDAL
    {
        public TeacherDAL(string connectionString) : base(connectionString)
        {
        }

        public List<Teacher> GetAllTeachers()
        {
            SqlConnection connection = GetConnection();
            connection.Open();
            SqlCommand command = new()
            {
                Connection = connection,
                CommandText = "SP_GetAllTeachers",
                CommandType = CommandType.StoredProcedure
            };

            DataTable dt = new();
            SqlDataAdapter adapter = new(command);
            adapter.Fill(dt);

            var query = dt.AsEnumerable().Select(x => new Teacher
            {
                TeacherId = Convert.ToInt32(x["teacher_id"]),
                FirstName = Convert.ToString(x["first_name"]),
                LastName = Convert.ToString(x["last_name"]),
                DateOfBirth = Convert.ToDateTime(x["date_of_birth"]),
                Address = Convert.ToString(x["address"]),
                PhoneNumber = Convert.ToString(x["phone_number"]),
                Email = Convert.ToString(x["email"]),
                DeletedDate = x["deleted_date"] != DBNull.Value ? Convert.ToDateTime(x["deleted_date"]) : null
            });

            return query.ToList();
        }

        public async Task<Teacher> GetTeacherById(int teacherId)
        {
            SqlConnection connection = GetConnection();
            connection.Open();
            SqlCommand command = new()
            {
                Connection = connection,
                CommandText = "SP_GetTeacherById",
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@pTeacherId", teacherId);

            SqlDataReader reader = await command.ExecuteReaderAsync();
            Teacher teacher = new();
            if (reader.Read())
            {
                teacher.TeacherId = Convert.ToInt32(reader["teacher_id"]);
                teacher.FirstName = Convert.ToString(reader["first_name"]);
                teacher.LastName = Convert.ToString(reader["last_name"]);
                teacher.DateOfBirth = Convert.ToDateTime(reader["date_of_birth"]);
                teacher.Address = Convert.ToString(reader["address"]);
                teacher.PhoneNumber = Convert.ToString(reader["phone_number"]);
                teacher.Email = Convert.ToString(reader["email"]);
                teacher.DeletedDate = reader["deleted_date"] != DBNull.Value ? Convert.ToDateTime(reader["deleted_date"]) : null;
            }

            return teacher;
        }

        public async Task<int> CreateTeacher(string fistName, string lastName, DateTime birthday, string address, string phoneNumber, string email)
        {
            SqlConnection connection = GetConnection();
            connection.Open();
            SqlCommand command = new()
            {
                Connection = connection,
                CommandText = "SP_CreateTeacher",
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@pFirstName", fistName);
            command.Parameters.AddWithValue("@pLastName", lastName);
            command.Parameters.AddWithValue("@pBirthday", birthday);
            command.Parameters.AddWithValue("@pAddress", address);
            command.Parameters.AddWithValue("@pPhoneNumber", phoneNumber);
            command.Parameters.AddWithValue("@pEmail", email);

            return await command.ExecuteNonQueryAsync();
        }

        public async Task<int> UpdateTeacher(int teacherId, string fistName, string lastName, DateTime birthday, string address, string phoneNumber, string email)
        {
            SqlConnection connection = GetConnection();
            connection.Open();
            SqlCommand command = new()
            {
                Connection = connection,
                CommandText = "SP_UpdateTeacher",
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@pTeacherId", teacherId);
            command.Parameters.AddWithValue("@pFirstName", fistName);
            command.Parameters.AddWithValue("@pLastName", lastName);
            command.Parameters.AddWithValue("@pBirthday", birthday);
            command.Parameters.AddWithValue("@pAddress", address);
            command.Parameters.AddWithValue("@pPhoneNumber", phoneNumber);
            command.Parameters.AddWithValue("@pEmail", email);

            return await command.ExecuteNonQueryAsync();
        }

        public async Task<int> DeleteTeacher(int teacherId, string deletedDate)
        {
            SqlConnection connection = GetConnection();
            connection.Open();
            SqlCommand command = new()
            {
                Connection = connection,
                CommandText = "SP_DeleteTeacher",
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@pTeacherId", teacherId);
            command.Parameters.AddWithValue("@pDeletedDate", deletedDate);

            return await command.ExecuteNonQueryAsync();
        }
    }
}
