using Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace SchoolDAL
{
    public class StudentDAL : SchoolBaseDAL
    {
        public StudentDAL(string connectionString) : base(connectionString)
        {
        }

        public List<Student> GetAllStudents()
        {
            SqlConnection connection = GetConnection();
            connection.Open();
            SqlCommand command = new()
            {
                Connection = connection,
                CommandText = "SP_GetAllStudents",
                CommandType = CommandType.StoredProcedure
            };

            DataTable dt = new();
            SqlDataAdapter adapter = new(command);
            adapter.Fill(dt);

            var query = dt.AsEnumerable().Select(x => new Student
            {
                StudentId = Convert.ToInt32(x["student_id"]),
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

        public async Task<Student> GetStudentById(int studentId)
        {
            SqlConnection connection = GetConnection();
            connection.Open();
            SqlCommand command = new()
            {
                Connection = connection,
                CommandText = "SP_GetStudentById",
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@pStudentId", studentId);

            SqlDataReader reader = await command.ExecuteReaderAsync();
            Student student = new();
            if (reader.Read())
            {
                student.StudentId = Convert.ToInt32(reader["student_id"]);
                student.FirstName = Convert.ToString(reader["first_name"]);
                student.LastName = Convert.ToString(reader["last_name"]);
                student.DateOfBirth = Convert.ToDateTime(reader["date_of_birth"]);
                student.Address = Convert.ToString(reader["address"]);
                student.PhoneNumber = Convert.ToString(reader["phone_number"]);
                student.Email = Convert.ToString(reader["email"]);
                student.DeletedDate = reader["deleted_date"] != DBNull.Value ? Convert.ToDateTime(reader["deleted_date"]) : null;
            }

            return student;
        }

        public async Task<int> CreateStudent(string fistName, string lastName, DateTime birthday, string address, string phoneNumber, string email)
        {
            SqlConnection connection = GetConnection();
            connection.Open();
            SqlCommand command = new()
            {
                Connection = connection,
                CommandText = "SP_CreateStudent",
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

        public async Task<int> UpdateStudent(int studentId, string fistName, string lastName, DateTime birthday, string address, string phoneNumber, string email)
        {
            SqlConnection connection = GetConnection();
            connection.Open();
            SqlCommand command = new()
            {
                Connection = connection,
                CommandText = "SP_UpdateStudent",
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@pStudentId", studentId);
            command.Parameters.AddWithValue("@pFirstName", fistName);
            command.Parameters.AddWithValue("@pLastName", lastName);
            command.Parameters.AddWithValue("@pBirthday", birthday);
            command.Parameters.AddWithValue("@pAddress", address);
            command.Parameters.AddWithValue("@pPhoneNumber", phoneNumber);
            command.Parameters.AddWithValue("@pEmail", email);

            return await command.ExecuteNonQueryAsync();
        }

        public async Task<int> DeleteStudent(int studentId, string deletedDate)
        {
            SqlConnection connection = GetConnection();
            connection.Open();
            SqlCommand command = new()
            {
                Connection = connection,
                CommandText = "SP_DeleteStudent",
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@pStudentId", studentId);
            command.Parameters.AddWithValue("@pDeletedDate", deletedDate);

            return await command.ExecuteNonQueryAsync();
        }
    }
}
