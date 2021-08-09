using Lessons_api.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lessons_api.Data.Interfaces
{
    public interface IUserRepository
    {
        Task<UserEntity> GetUserById(int id);
        Task<List<UserEntity>> GetAllUsers();
        Task<UserEntity> AddUser(UserEntity userEntity);
        Task<UserEntity> UpdateUser(int id, UserEntity userEntity);
        Task DeleteUserById(int id);
    }
}
