using Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace SchoolDAL
{
    public class EvaluationDAL : SchoolBaseDAL
    {
        public EvaluationDAL(string connectionString) : base(connectionString)
        {
        }

        public List<Evaluation> GetAllEvaluations()
        {
            SqlConnection connection = GetConnection();
            connection.Open();
            SqlCommand command = new()
            {
                Connection = connection,
                CommandText = "SP_GetAllEvaluations",
                CommandType = CommandType.StoredProcedure
            };

            DataTable dt = new();
            SqlDataAdapter adapter = new(command);
            adapter.Fill(dt);

            var query = dt.AsEnumerable().Select(x => new Evaluation
            {
                EvaluationId = Convert.ToInt32(x["evaluation_id"]),
                EnrollmentId = Convert.ToInt32(x["enrollment_id"]),
                EvaluationDate = Convert.ToDateTime(x["evaluation_date"]),
                EvaluationType = Convert.ToString(x["evaluation_type"]),
                Score = Convert.ToDecimal(x["score"]),
                DeletedDate = x["deleted_date"] != DBNull.Value ? Convert.ToDateTime(x["deleted_date"]) : null
            });

            return query.ToList();
        }

        public async Task<Evaluation> GetEvaluationById(int evaluationId)
        {
            SqlConnection connection = GetConnection();
            connection.Open();
            SqlCommand command = new()
            {
                Connection = connection,
                CommandText = "SP_GetEvaluationById",
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@pEvaluationId", evaluationId);

            SqlDataReader reader = await command.ExecuteReaderAsync();
            Evaluation evaluation = new();
            if (reader.Read())
            {
                evaluation.EvaluationId = Convert.ToInt32(reader["evaluation_id"]);
                evaluation.EnrollmentId = Convert.ToInt32(reader["enrollment_id"]);
                evaluation.EvaluationDate = Convert.ToDateTime(reader["evaluation_date"]);
                evaluation.EvaluationType = Convert.ToString(reader["evaluation_type"]);
                evaluation.Score = Convert.ToDecimal(reader["score"]);
                evaluation.DeletedDate = reader["deleted_date"] != DBNull.Value ? Convert.ToDateTime(reader["deleted_date"]) : null;
            }

            return evaluation;
        }

        public async Task<int> CreateEvaluation(int enrollmentId, DateTime evaluationDate, string evaluationType, Decimal score)
        {
            SqlConnection connection = GetConnection();
            connection.Open();
            SqlCommand command = new()
            {
                Connection = connection,
                CommandText = "SP_CreateEvaluation",
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@pEnrollmentId", enrollmentId);
            command.Parameters.AddWithValue("@pEvaluationDate", evaluationDate);
            command.Parameters.AddWithValue("@pEvaluationType", evaluationType);
            command.Parameters.AddWithValue("@pScore", score);

            return await command.ExecuteNonQueryAsync();
        }

        public async Task<int> UpdateEvaluation(int evaluationId, int enrollmentId, DateTime evaluationDate, string evaluationType, Decimal score)
        {
            SqlConnection connection = GetConnection();
            connection.Open();
            SqlCommand command = new()
            {
                Connection = connection,
                CommandText = "SP_UpdateEvaluation",
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@pEvaluationId", evaluationId);
            command.Parameters.AddWithValue("@pEnrollmentId", enrollmentId);
            command.Parameters.AddWithValue("@pEvaluationDate", evaluationDate);
            command.Parameters.AddWithValue("@pEvaluationType", evaluationType);
            command.Parameters.AddWithValue("@pScore", score);

            return await command.ExecuteNonQueryAsync();
        }

        public async Task<int> DeleteEvaluation(int evaluationId, string deletedDate)
        {
            SqlConnection connection = GetConnection();
            connection.Open();
            SqlCommand command = new()
            {
                Connection = connection,
                CommandText = "SP_DeleteEvaluation",
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@pEvaluationId", evaluationId);
            command.Parameters.AddWithValue("@pDeletedDate", deletedDate);

            return await command.ExecuteNonQueryAsync();
        }
    }
}
