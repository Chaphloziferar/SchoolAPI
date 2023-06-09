using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBLL.Interfaces
{
    public interface IEvaluationBLL
    {
        Task<List<Evaluation>> GetAllEvaluations();
        Task<Evaluation> GetEvaluationById(int evaluationId);
        Task<int> CreateEvaluation(int enrollmentId, DateTime evaluationDate, string evaluationType, Decimal score);
        Task<int> UpdateEvaluation(int evaluationId, int enrollmentId, DateTime evaluationDate, string evaluationType, Decimal score);
        Task<int> DeleteEvaluation(int evaluationId, string deletedDate);
    }
}
