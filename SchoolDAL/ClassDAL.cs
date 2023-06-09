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
    public class ClassDAL : SchoolBaseDAL
    {
        public ClassDAL(string connectionString) : base(connectionString)
        {
        }

        public List<Class> GetAllClasses()
        {
            SqlConnection connection = GetConnection();
            connection.Open();
            SqlCommand command = new()
            {
                Connection = connection,
                CommandText = "SP_GetAllClasses",
                CommandType = CommandType.StoredProcedure
            };

            DataTable dt = new();
            SqlDataAdapter adapter = new(command);
            adapter.Fill(dt);

            var query = dt.AsEnumerable().Select(x => new Class
            {
                ClassId = Convert.ToInt32(x["class_id"]),
                ClassName = Convert.ToString(x["class_name"]),
                TeacherId = Convert.ToInt32(x["teacher_id"]),
                DeletedDate = x["deleted_date"] != DBNull.Value ? Convert.ToDateTime(x["deleted_date"]) : null
            });

            return query.ToList();
        }

        public async Task<Class> GetClassById(int classId)
        {
            SqlConnection connection = GetConnection();
            connection.Open();
            SqlCommand command = new()
            {
                Connection = connection,
                CommandText = "SP_GetClassById",
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@pClassId", classId);

            SqlDataReader reader = await command.ExecuteReaderAsync();
            Class @class = new();
            if (reader.Read())
            {
                @class.ClassId = Convert.ToInt32(reader["class_id"]);
                @class.ClassName = Convert.ToString(reader["class_name"]);
                @class.TeacherId = Convert.ToInt32(reader["teacher_id"]);
                @class.DeletedDate = reader["deleted_date"] != DBNull.Value ? Convert.ToDateTime(reader["deleted_date"]) : null;
            }

            return @class;
        }

        public async Task<int> CreateClass(string className, int teacherId)
        {
            SqlConnection connection = GetConnection();
            connection.Open();
            SqlCommand command = new()
            {
                Connection = connection,
                CommandText = "SP_CreateClass",
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@pClassName", className);
            command.Parameters.AddWithValue("@pTeacherId", teacherId);

            return await command.ExecuteNonQueryAsync();
        }

        public async Task<int> UpdateClass(int classId, string className, int teacherId)
        {
            SqlConnection connection = GetConnection();
            connection.Open();
            SqlCommand command = new()
            {
                Connection = connection,
                CommandText = "SP_UpdateClass",
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@pClassId", classId);
            command.Parameters.AddWithValue("@pClassName", className);
            command.Parameters.AddWithValue("@pTeacherId", teacherId);

            return await command.ExecuteNonQueryAsync();
        }

        public async Task<int> DeleteClass(int classId, string deletedDate)
        {
            SqlConnection connection = GetConnection();
            connection.Open();
            SqlCommand command = new()
            {
                Connection = connection,
                CommandText = "SP_DeleteClass",
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@pClassId", classId);
            command.Parameters.AddWithValue("@pDeletedDate", deletedDate);

            return await command.ExecuteNonQueryAsync();
        }
    }
}
