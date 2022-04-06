using Lessons_api.Domain.UserModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lessons_api.Domain.Interfaces
{
    public interface IUserService
    {
        Task<UserDTO> GetUserById(int id);
        Task<List<UserDTO>> GetAllUsers();
        Task<BaseUserDTO> AddUser(BaseUserDTO model);
        Task<BaseUserDTO> UpdateUser(int id, BaseUserDTO model);
        Task DeleteUserById(int id);
    }
}
