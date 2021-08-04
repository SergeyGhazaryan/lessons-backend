using Lessons_api.Domain.UserModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lessons_api.Domain.Interfaces
{
    public interface IUserService
    {
        Task<UserDTO> GetUserById(int id);
        Task<List<UserDTO>> GetAllUsers();
        Task<AddUserDTO> AddUser(AddUserDTO model);
        Task<UpdateUserDTO> UpdateUser(int id, UpdateUserDTO model);
        Task DeleteUserById(int id);
    }
}
