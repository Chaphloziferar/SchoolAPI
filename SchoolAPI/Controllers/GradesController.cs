using Entities;
using Microsoft.AspNetCore.Mvc;
using SchoolBLL.Interfaces;
using System.Diagnostics;

namespace SchoolAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradesController : ControllerBase
    {
        private readonly IGradeBLL _bll;
        public GradesController(IGradeBLL bll)
        {
            _bll = bll;
        }

        /// <summary>
        /// Retorna una lista de todas las notas.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<Grade>> GetAllEnrollments()
        {
            return await _bll.GetAllGrades();
        }

        /// <summary>
        /// Obtiene una nota por su ID.
        /// </summary>
        /// <param name="gradeId">ID de la nota.</param>
        /// <returns><see cref="Grade"/>></returns>
        [HttpGet("{gradeId}")]
        public async Task<Grade> GetGradeById(int gradeId)
        {
            return await _bll.GetGradeById(gradeId);
        }

        /// <summary>
        /// Crea una nueva nota.
        /// </summary>
        /// <param name="grade">Datos de la nota.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<int> CreateClass(Grade grade)
        {
            return await _bll.CreateGrade(grade.EnrollmentId, grade.GradeValue);
        }

        /// <summary>
        /// Editar una nota.
        /// </summary>
        /// <param name="grade">Datos de la nota.</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<int> UpdateGrade(Grade grade)
        {
            return await _bll.UpdateGrade(grade.GradeId, grade.EnrollmentId, grade.GradeValue);
        }

        /// <summary>
        /// Marcar como eliminada una nota.
        /// </summary>
        /// <param name="classId">ID de la nota.</param>
        /// <param name="deletedDate">Fecha de eliminacion.</param>
        /// <returns></returns>
        [HttpDelete("{classId}")]
        public async Task<int> DeleteGrade(int classId, string deletedDate)
        {
            return await _bll.DeleteGrade(classId, deletedDate);
        }
    }
}
