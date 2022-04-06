using AutoMapper;
using Lessons_api.Data.Interfaces;
using Lessons_api.Data.Models;
using Lessons_api.Domain.Interfaces;
using Lessons_api.Domain.TeacherModel;
using Lessons_api.Domain.UserModel;
using ServiceStack.Host;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lessons_api.Domain.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITeacherRepository _teacherRepository;
        private readonly IMapper _mapper;

        public TeacherService(IUserRepository userRepository, ITeacherRepository teacherRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _teacherRepository = teacherRepository;
            _mapper = mapper;
        }

        public async Task<TeacherDTO> GetTeacherById(int id)
        {
            var teacher = await _teacherRepository.GetTeacherById(id);

            if (teacher == null)
            {
                throw new HttpException(404, "Not Found");
            }

            var teacherDTO = _mapper.Map<TeacherDTO>(teacher);

            return teacherDTO;
        }
        public async Task<List<TeacherDTO>> GetAllTeachers()
        {
            var teachers = await _teacherRepository.GetAllTeachers();

            if (!teachers.Any())
            {
                throw new HttpException(404, "Not Found");
            }

            var teacherDTOList = _mapper.Map<List<TeacherDTO>>(teachers);

            return teacherDTOList;
        }

        public async Task<BaseUserDTO> AddTeacher(CreateUserDTO model)
        {
            var user = await _userRepository.GetUserById(model.UserId);

            if (user == null)
            {
                throw new HttpException(404, "Not Found");
            }

            var teacherEntity = new TeacherEntity() { UserId = model.UserId };
            var addedTeacher = await _teacherRepository.AddTeacher(teacherEntity);

            if (addedTeacher == null)
            {
                throw new HttpException(404, "Not Found");
            }

            var addedTeacherDTO = _mapper.Map<BaseUserDTO>(addedTeacher);

            return addedTeacherDTO;
        }

        public async Task<BaseUserDTO> UpdateTeacher(int id, BaseUserDTO model)
        {
            var userEntity = _mapper.Map<UserEntity>(model);
            var updatedTeacher = await _teacherRepository.UpdateTeacher(id, userEntity);

            if (updatedTeacher == null)
            {
                throw new HttpException(404, "Not Found");
            }

            var updatedTeacherDTO = _mapper.Map<BaseUserDTO>(updatedTeacher);

            return updatedTeacherDTO;
        }

        public async Task DeleteTeacherById(int id)
        {
            var deletedUserId = await _teacherRepository.DeleteTeacherById(id);
            await _userRepository.DeleteUserById(deletedUserId);
        }
    }
}
