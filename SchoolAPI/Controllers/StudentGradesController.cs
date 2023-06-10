using Entities;
using Microsoft.AspNetCore.Mvc;
using SchoolBLL.Interfaces;

namespace SchoolAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentGradesController : Controller
    {
        private readonly IStudentGradeBLL _bll;
        public StudentGradesController(IStudentGradeBLL studentGradeBLL)
        {
            _bll = studentGradeBLL;
        }

        /// <summary>
        /// Obtiene la lista de notas por estudiante buscando por ID.
        /// </summary>
        /// <param name="studentId">ID del estudiante.</param>
        /// <returns><see cref="StudentGrade"/>></returns>
        [HttpGet("{studentId}")]
        public async Task<List<StudentGrade>> GetAllStudentsGradesById(int studentId)
        {
            return await _bll.GetAllStudentsGradesById(studentId);
        }
    }
}
