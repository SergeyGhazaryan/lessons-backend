using AutoMapper;
using Lessons_api.Data.Interfaces;
using Lessons_api.Data.Models;
using Lessons_api.Domain.Interfaces;
using Lessons_api.Domain.UserModel;
using ServiceStack.Host;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lessons_api.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDTO> GetUserById(int id)
        {
            var user = await _userRepository.GetUserById(id);

            if (user == null)
            {
                throw new HttpException(404, "Not Found");
            }

            var userDTO = _mapper.Map<UserDTO>(user);

            return userDTO;
        }

        public async Task<List<UserDTO>> GetAllUsers()
        {
            var users = await _userRepository.GetAllUsers();

            if (users == null)
            {
                throw new HttpException(404, "Not Found");
            }

            var userDTOList = _mapper.Map<List<UserDTO>>(users);

            return userDTOList;
        }

        public async Task<BaseUserDTO> AddUser(BaseUserDTO model)
        {
            var userEntity = _mapper.Map<UserEntity>(model);
            var addedUser = await _userRepository.AddUser(userEntity);

            if (addedUser == null)
            {
                throw new HttpException(404, "Not Found");
            }

            var addedUserDTO = _mapper.Map<BaseUserDTO>(addedUser);
            return addedUserDTO;
        }

        public async Task<BaseUserDTO> UpdateUser(int id, BaseUserDTO model)
        {
            var userEntity = _mapper.Map<UserEntity>(model);
            var updatedUser = await _userRepository.UpdateUser(id, userEntity);

            if (updatedUser == null)
            {
                throw new HttpException(404, "Not Found");
            }

            var updatedUserDTO = _mapper.Map<BaseUserDTO>(updatedUser);
            return updatedUserDTO;
        }

        public async Task DeleteUserById(int id)
        {
            await _userRepository.DeleteUserById(id);
        }
    }
}
