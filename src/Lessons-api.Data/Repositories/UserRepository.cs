using Lessons_api.Data.Context;
using Lessons_api.Data.Interfaces;
using Lessons_api.Data.Models;
using Microsoft.EntityFrameworkCore;
using ServiceStack.Host;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lessons_api.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly LessonsContext _lessonsContext;

        public UserRepository(LessonsContext lessonsContext)
        {
            _lessonsContext = lessonsContext;
        }

        public async Task<UserEntity> GetUserById(int id)
        {
            var result = await _lessonsContext.Users.Where(u => u.Id == id).FirstOrDefaultAsync();

            return result;
        }

        public async Task<List<UserEntity>> GetAllUsers()
        {
            var result = await _lessonsContext.Users.ToListAsync();

            return result;
        }

        public async Task<UserEntity> AddUser(UserEntity userEntity)
        {
            await _lessonsContext.Users.AddAsync(userEntity);
            await _lessonsContext.SaveChangesAsync();

            return userEntity;
        }

        public async Task<UserEntity> UpdateUser(int id, UserEntity userEntity)
        {
            var updatedUser = await _lessonsContext.Users.FindAsync(id);

            if (updatedUser == null)
            {
                throw new HttpException(404, "Not Found");
            }

            updatedUser.FirstName = userEntity.FirstName;
            updatedUser.LastName = userEntity.LastName;
            updatedUser.Country = userEntity.Country;
            updatedUser.City = userEntity.City;
            updatedUser.Age = userEntity.Age;
            await _lessonsContext.SaveChangesAsync();

            return updatedUser;
        }

        public async Task DeleteUserById(int id)
        {
            var deletedUser = await _lessonsContext.Users.Where(u => u.Id == id).FirstOrDefaultAsync();

            if (deletedUser == null)
            {
                throw new HttpException(404, "Not Found");
            }

            _lessonsContext.Users.Remove(deletedUser);
            await _lessonsContext.SaveChangesAsync();
        }
    }
}
