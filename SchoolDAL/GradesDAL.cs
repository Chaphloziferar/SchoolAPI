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
    public class GradesDAL : SchoolBaseDAL
    {
        public GradesDAL(string connectionString) : base(connectionString)
        {
        }

        public List<Grade> GetAllGrades()
        {
            SqlConnection connection = GetConnection();
            connection.Open();
            SqlCommand command = new()
            {
                Connection = connection,
                CommandText = "SP_GetAllGrades",
                CommandType = CommandType.StoredProcedure
            };

            DataTable dt = new();
            SqlDataAdapter adapter = new(command);
            adapter.Fill(dt);

            var query = dt.AsEnumerable().Select(x => new Grade
            {
                GradeId = Convert.ToInt32(x["grade_id"]),
                EnrollmentId = Convert.ToInt32(x["enrollment_id"]),
                GradeValue = Convert.ToDecimal(x["grade"]),
                DeletedDate = x["deleted_date"] != DBNull.Value ? Convert.ToDateTime(x["deleted_date"]) : null
            });

            return query.ToList();
        }

        public async Task<Grade> GetGradeById(int gradeId)
        {
            SqlConnection connection = GetConnection();
            connection.Open();
            SqlCommand command = new()
            {
                Connection = connection,
                CommandText = "SP_GetGradeById",
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@pGradeId", gradeId);

            SqlDataReader reader = await command.ExecuteReaderAsync();
            Grade grade = new();
            if (reader.Read())
            {
                grade.GradeId = Convert.ToInt32(reader["grade_id"]);
                grade.EnrollmentId = Convert.ToInt32(reader["enrollment_id"]);
                grade.GradeValue = Convert.ToDecimal(reader["grade"]);
                grade.DeletedDate = reader["deleted_date"] != DBNull.Value ? Convert.ToDateTime(reader["deleted_date"]) : null;
            }

            return grade;
        }

        public async Task<int> CreateGrade(int enrollmentId, Decimal grade)
        {
            SqlConnection connection = GetConnection();
            connection.Open();
            SqlCommand command = new()
            {
                Connection = connection,
                CommandText = "SP_CreateGrade",
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@pEnrollmentId", enrollmentId);
            command.Parameters.AddWithValue("@pGrade", grade);

            return await command.ExecuteNonQueryAsync();
        }

        public async Task<int> UpdateGrade(int gradeId, int enrollmentId, Decimal grade)
        {
            SqlConnection connection = GetConnection();
            connection.Open();
            SqlCommand command = new()
            {
                Connection = connection,
                CommandText = "SP_UpdateGrade",
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@pGradeId", gradeId);
            command.Parameters.AddWithValue("@pEnrollmentId", enrollmentId);
            command.Parameters.AddWithValue("@pGrade", grade);

            return await command.ExecuteNonQueryAsync();
        }

        public async Task<int> DeleteGrade(int gradeId, string deletedDate)
        {
            SqlConnection connection = GetConnection();
            connection.Open();
            SqlCommand command = new()
            {
                Connection = connection,
                CommandText = "SP_DeleteGrade",
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@pGradeId", gradeId);
            command.Parameters.AddWithValue("@pDeletedDate", deletedDate);

            return await command.ExecuteNonQueryAsync();
        }
    }
}
