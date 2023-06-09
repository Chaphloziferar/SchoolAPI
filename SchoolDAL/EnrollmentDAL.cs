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
    public class EnrollmentDAL : SchoolBaseDAL
    {
        public EnrollmentDAL(string connectionString) : base(connectionString)
        {
        }

        public List<Enrollment> GetAllEnrollments()
        {
            SqlConnection connection = GetConnection();
            connection.Open();
            SqlCommand command = new()
            {
                Connection = connection,
                CommandText = "SP_GetAllEnrollments",
                CommandType = CommandType.StoredProcedure
            };

            DataTable dt = new();
            SqlDataAdapter adapter = new(command);
            adapter.Fill(dt);

            var query = dt.AsEnumerable().Select(x => new Enrollment
            {
                EnrollmentId = Convert.ToInt32(x["enrollment_id"]),
                StudentId = Convert.ToInt32(x["student_id"]),
                ClassId = Convert.ToInt32(x["class_id"]),
                EnrollmentDate = Convert.ToDateTime(x["enrollment_date"]),
                DeletedDate = x["deleted_date"] != DBNull.Value ? Convert.ToDateTime(x["deleted_date"]) : null
            });

            return query.ToList();
        }

        public async Task<Enrollment> GetEnrollmentById(int enrollmentId)
        {
            SqlConnection connection = GetConnection();
            connection.Open();
            SqlCommand command = new()
            {
                Connection = connection,
                CommandText = "SP_GetEnrollmentById",
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@pEnrollmentId", enrollmentId);

            SqlDataReader reader = await command.ExecuteReaderAsync();
            Enrollment enrollment = new();
            if (reader.Read())
            {
                enrollment.EnrollmentId = Convert.ToInt32(reader["enrollment_id"]);
                enrollment.StudentId = Convert.ToInt32(reader["student_id"]);
                enrollment.ClassId = Convert.ToInt32(reader["class_id"]);
                enrollment.EnrollmentDate = Convert.ToDateTime(reader["enrollment_date"]);
                enrollment.DeletedDate = reader["deleted_date"] != DBNull.Value ? Convert.ToDateTime(reader["deleted_date"]) : null;
            }

            return enrollment;
        }

        public async Task<int> CreateEnrollment(int studentId, int classId, DateTime enrollmentDate)
        {
            SqlConnection connection = GetConnection();
            connection.Open();
            SqlCommand command = new()
            {
                Connection = connection,
                CommandText = "SP_CreateEnrollment",
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@pStudentId", studentId);
            command.Parameters.AddWithValue("@pClassId", classId);
            command.Parameters.AddWithValue("@pEnrollmentDate", enrollmentDate);

            return await command.ExecuteNonQueryAsync();
        }

        public async Task<int> UpdateEnrollment(int enrollmentId, int studentId, int classId, DateTime enrollmentDate)
        {
            SqlConnection connection = GetConnection();
            connection.Open();
            SqlCommand command = new()
            {
                Connection = connection,
                CommandText = "SP_UpdateEnrollment",
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@pEnrollmentId", enrollmentId);
            command.Parameters.AddWithValue("@pStudentId", studentId);
            command.Parameters.AddWithValue("@pClassId", classId);
            command.Parameters.AddWithValue("@pEnrollmentDate", enrollmentDate);

            return await command.ExecuteNonQueryAsync();
        }

        public async Task<int> DeleteEnrollment(int enrollmentId, string deletedDate)
        {
            SqlConnection connection = GetConnection();
            connection.Open();
            SqlCommand command = new()
            {
                Connection = connection,
                CommandText = "SP_DeleteEnrollment",
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@pEnrollmentId", enrollmentId);
            command.Parameters.AddWithValue("@pDeletedDate", deletedDate);

            return await command.ExecuteNonQueryAsync();
        }
    }
}
