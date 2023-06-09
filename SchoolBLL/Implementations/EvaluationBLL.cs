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
    public class EvaluationBLL : IEvaluationBLL
    {
        private readonly IConfiguration _configuration;
        private readonly EvaluationDAL dbEvaluation;
        public EvaluationBLL(IConfiguration configuration)
        {
            _configuration = configuration;
            string connectionString = _configuration.GetConnectionString(name: "DefaultConnectionString");
            dbEvaluation = new EvaluationDAL(connectionString);
        }

        public async Task<List<Evaluation>> GetAllEvaluations()
        {
            return dbEvaluation.GetAllEvaluations();
        }

        public async Task<Evaluation> GetEvaluationById(int evaluationId)
        {
            return await dbEvaluation.GetEvaluationById(evaluationId);
        }

        public async Task<int> CreateEvaluation(int enrollmentId, DateTime evaluationDate, string evaluationType, decimal score)
        {
            return await dbEvaluation.CreateEvaluation(enrollmentId, evaluationDate, evaluationType, score);
        }

        public async Task<int> UpdateEvaluation(int evaluationId, int enrollmentId, DateTime evaluationDate, string evaluationType, decimal score)
        {
            return await dbEvaluation.UpdateEvaluation(evaluationId, enrollmentId, evaluationDate, evaluationType, score);
        }

        public async Task<int> DeleteEvaluation(int evaluationId, string deletedDate)
        {
            return await dbEvaluation.DeleteEvaluation(evaluationId, deletedDate);
        }
    }
}
