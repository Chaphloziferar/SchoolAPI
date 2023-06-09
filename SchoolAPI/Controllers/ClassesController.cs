using Entities;
using Microsoft.AspNetCore.Mvc;
using SchoolBLL.Interfaces;

namespace SchoolAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassesController : ControllerBase
    {
        private readonly IClassBLL _bll;
        public ClassesController(IClassBLL bll)
        {
            _bll = bll;
        }

        /// <summary>
        /// Retorna una lista de todas las clases.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<Class>> GetAllClasses()
        {
            return await _bll.GetAllClasses();
        }

        /// <summary>
        /// Obtiene una clase por su ID.
        /// </summary>
        /// <param name="classId">ID de la clase.</param>
        /// <returns><see cref="Class"/>></returns>
        [HttpGet("{classId}")]
        public async Task<Class> GetClassById(int classId)
        {
            return await _bll.GetClassById(classId);
        }

        /// <summary>
        /// Crea una nueva clase.
        /// </summary>
        /// <param name="class">Datos de la clase.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<int> CreateClass(Class @class)
        {
            return await _bll.CreateClass(@class.ClassName, @class.TeacherId);
        }

        /// <summary>
        /// Editar una clase.
        /// </summary>
        /// <param name="class">Datos de la clase.</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<int> UpdateClass(Class @class)
        {
            return await _bll.UpdateClass(@class.ClassId, @class.ClassName, @class.TeacherId);
        }

        /// <summary>
        /// Marcar como eliminada una clase.
        /// </summary>
        /// <param name="classId">ID de la clase.</param>
        /// <param name="deletedDate">Fecha de eliminacion.</param>
        /// <returns></returns>
        [HttpDelete("{classId}")]
        public async Task<int> DeleteClass(int classId, string deletedDate)
        {
            return await _bll.DeleteClass(classId, deletedDate);
        }
    }
}
