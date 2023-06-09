using Entities;
using Microsoft.AspNetCore.Mvc;
using SchoolBLL.Interfaces;

namespace SchoolAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserBLL _bll;
        public UsersController(IUserBLL userBLL)
        {
            _bll = userBLL;
        }

        /// <summary>
        /// Retorna una lista de todos los usuarios.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<User>> GetAllUsers()
        {
            return await _bll.GetAllUsers();
        }

        /// <summary>
        /// Obtiene un usuario por su ID.
        /// </summary>
        /// <param name="id">ID del usuario.</param>
        /// <returns><see cref="User"/>></returns>
        [HttpGet("{userId}")]
        public async Task<User> GetUserById(int userId)
        {
            return await _bll.GetUserById(userId);
        }

        /// <summary>
        /// Crea un nuevo usuario.
        /// </summary>
        /// <param name="user">Datos del usuario.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<int> CreateUser(User user)
        {
            return await _bll.CreateUser(user.Username, user.Password, user.UserType);
        }

        /// <summary>
        /// Editar el rol de un usuario.
        /// </summary>
        /// <param name="userId">ID del usuario.</param>
        /// <param name="userType">Rol del usuario.</param>
        /// <returns></returns>
        [HttpPut("{userId}")]
        public async Task<int> UpdateUserType(int userId, string userType)
        {
            return await _bll.UpdateUserType(userId, userType);
        }

        /// <summary>
        /// Marcar como eliminado a un usuario.
        /// </summary>
        /// <param name="userId">ID del usuario.</param>
        /// <param name="deletedDate">Fecha de eliminacion.</param>
        /// <returns></returns>
        [HttpDelete("{userId}")]
        public async Task<int> DeleteUser(int userId, string deletedDate)
        {
            return await _bll.DeleteUser(userId, deletedDate);
        }
    }
}
