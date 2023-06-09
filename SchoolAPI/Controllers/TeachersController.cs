using Entities;
using Microsoft.AspNetCore.Mvc;
using SchoolBLL.Interfaces;

namespace SchoolAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly ITeacherBLL _bll;
        public TeachersController(ITeacherBLL bll)
        {
            _bll = bll;
        }

        /// <summary>
        /// Retorna una lista de todos los docentes.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<Teacher>> GetAllTeachers()
        {
            return await _bll.GetAllTeachers();
        }

        /// <summary>
        /// Obtiene un docente por su ID.
        /// </summary>
        /// <param name="teacherId">ID del docente.</param>
        /// <returns><see cref="Teacher"/>></returns>
        [HttpGet("{teacherId}")]
        public async Task<Teacher> GetTeacherById(int teacherId)
        {
            return await _bll.GetTeacherById(teacherId);
        }

        /// <summary>
        /// Crea un nuevo docente.
        /// </summary>
        /// <param name="teacher">Datos del docente.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<int> CreateTeacher(Teacher teacher)
        {
            return await _bll.CreateTeacher(teacher.FirstName, teacher.LastName, teacher.DateOfBirth, teacher.Address, teacher.PhoneNumber, teacher.Email);
        }

        /// <summary>
        /// Editar a un docente.
        /// </summary>
        /// <param name="teacher">Datos del docente.</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<int> UpdateTeacher(Teacher teacher)
        {
            return await _bll.UpdateTeacher(teacher.TeacherId, teacher.FirstName, teacher.LastName, teacher.DateOfBirth, teacher.Address, teacher.PhoneNumber, teacher.Email);
        }

        /// <summary>
        /// Marcar como eliminado a un docente.
        /// </summary>
        /// <param name="teacherId">ID del usuario.</param>
        /// <param name="deletedDate">Fecha de eliminacion.</param>
        /// <returns></returns>
        [HttpDelete("{teacherId}")]
        public async Task<int> DeleteTeacher(int teacherId, string deletedDate)
        {
            return await _bll.DeleteTeacher(teacherId, deletedDate);
        }
    }
}
