using Entities;
using Microsoft.AspNetCore.Mvc;
using SchoolBLL.Interfaces;

namespace SchoolAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentBLL _bll;
        public StudentsController(IStudentBLL bll)
        {
            _bll = bll;
        }

        /// <summary>
        /// Retorna una lista de todos los estudiantes.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<Student>> GetAllStudents()
        {
            return await _bll.GetAllStudents();
        }

        /// <summary>
        /// Obtiene un estudiante por su ID.
        /// </summary>
        /// <param name="studentId">ID del estudiante.</param>
        /// <returns><see cref="Student"/>></returns>
        [HttpGet("{studentId}")]
        public async Task<Student> GetStudentById(int studentId)
        {
            return await _bll.GetStudentById(studentId);
        }

        /// <summary>
        /// Crea un nuevo estudiante.
        /// </summary>
        /// <param name="student">Datos del estudiante.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<int> CreateStudent(Student student)
        {
            return await _bll.CreateStudent(student.FirstName, student.LastName, student.DateOfBirth, student.Address, student.PhoneNumber, student.Email);
        }

        /// <summary>
        /// Editar a un estudiante.
        /// </summary>
        /// <param name="student">Datos del estudiante.</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<int> UpdateStudent(Student student)
        {
            return await _bll.UpdateStudent(student.StudentId, student.FirstName, student.LastName, student.DateOfBirth, student.Address, student.PhoneNumber, student.Email);
        }

        /// <summary>
        /// Marcar como eliminado a un usuario.
        /// </summary>
        /// <param name="studentId">ID del usuario.</param>
        /// <param name="deletedDate">Fecha de eliminacion.</param>
        /// <returns></returns>
        [HttpDelete("{studentId}")]
        public async Task<int> DeleteStudent(int studentId, string deletedDate)
        {
            return await _bll.DeleteStudent(studentId, deletedDate);
        }
    }
}
