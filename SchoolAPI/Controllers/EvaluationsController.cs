using Entities;
using Microsoft.AspNetCore.Mvc;
using SchoolBLL.Interfaces;

namespace SchoolAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EvaluationsController : ControllerBase
    {
        private readonly IEvaluationBLL _bll;
        public EvaluationsController(IEvaluationBLL bll)
        {
            _bll = bll;
        }

        /// <summary>
        /// Retorna una lista de todas las evaluaciones.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<Evaluation>> GetAllEvaluations()
        {
            return await _bll.GetAllEvaluations();
        }

        /// <summary>
        /// Obtiene una evaluacion por su ID.
        /// </summary>
        /// <param name="evaluationId">ID de la evaluacion.</param>
        /// <returns><see cref="Evaluation"/>></returns>
        [HttpGet("{evaluationId}")]
        public async Task<Evaluation> GetEvaluationById(int evaluationId)
        {
            return await _bll.GetEvaluationById(evaluationId);
        }

        /// <summary>
        /// Crea una nueva evaluacion.
        /// </summary>
        /// <param name="evaluation">Datos de la evaluacion.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<int> CreateEvaluation(Evaluation evaluation)
        {
            return await _bll.CreateEvaluation(evaluation.EnrollmentId, evaluation.EvaluationDate, evaluation.EvaluationType, evaluation.Score);
        }

        /// <summary>
        /// Editar una evaluacion.
        /// </summary>
        /// <param name="evaluation">Datos de la evaluacion.</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<int> UpdateEvaluation(Evaluation evaluation)
        {
            return await _bll.UpdateEvaluation(evaluation.EvaluationId, evaluation.EnrollmentId, evaluation.EvaluationDate, evaluation.EvaluationType, evaluation.Score);
        }

        /// <summary>
        /// Marcar como eliminada una evaluacion.
        /// </summary>
        /// <param name="evaluationId">ID de la evaluacion.</param>
        /// <param name="deletedDate">Fecha de eliminacion.</param>
        /// <returns></returns>
        [HttpDelete("{evaluationId}")]
        public async Task<int> DeleteEvaluation(int evaluationId, string deletedDate)
        {
            return await _bll.DeleteEvaluation(evaluationId, deletedDate);
        }
    }
}
