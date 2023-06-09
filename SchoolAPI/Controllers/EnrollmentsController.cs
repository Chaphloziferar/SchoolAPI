using Entities;
using Microsoft.AspNetCore.Mvc;
using SchoolBLL.Interfaces;

namespace SchoolAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentsController : ControllerBase
    {
        private readonly IEnrollmentBLL _bll;
        public EnrollmentsController(IEnrollmentBLL bll)
        {
            _bll = bll;
        }

        /// <summary>
        /// Retorna una lista de todas las inscripciones.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<Enrollment>> GetAllEnrollments()
        {
            return await _bll.GetAllEnrollments();
        }

        /// <summary>
        /// Obtiene una inscripcion por su ID.
        /// </summary>
        /// <param name="enrollmentId">ID de la inscripcion.</param>
        /// <returns><see cref="Enrollment"/>></returns>
        [HttpGet("{enrollmentId}")]
        public async Task<Enrollment> GetClassById(int enrollmentId)
        {
            return await _bll.GetEnrollmentById(enrollmentId);
        }

        /// <summary>
        /// Crea una nueva inscripcion.
        /// </summary>
        /// <param name="enrollment">Datos de la inscripcion.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<int> CreateClass(Enrollment enrollment)
        {
            return await _bll.CreateEnrollment(enrollment.StudentId, enrollment.ClassId, enrollment.EnrollmentDate);
        }

        /// <summary>
        /// Editar una inscripcion.
        /// </summary>
        /// <param name="enrollment">Datos de la inscripcion.</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<int> UpdateClass(Enrollment enrollment)
        {
            return await _bll.UpdateEnrollment(enrollment.EnrollmentId, enrollment.StudentId, enrollment.ClassId, enrollment.EnrollmentDate);
        }

        /// <summary>
        /// Marcar como eliminada una inscripcion.
        /// </summary>
        /// <param name="enrollmentId">ID de la inscripcion.</param>
        /// <param name="deletedDate">Fecha de eliminacion.</param>
        /// <returns></returns>
        [HttpDelete("{enrollmentId}")]
        public async Task<int> DeleteClass(int enrollmentId, string deletedDate)
        {
            return await _bll.DeleteEnrollment(enrollmentId, deletedDate);
        }
    }
}
