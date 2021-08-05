using AutoMapper;
using Lessons_api.Data.Interfaces;
using Lessons_api.Data.Models;
using Lessons_api.Domain.Interfaces;
using Lessons_api.Domain.StudentModel;
using Lessons_api.Domain.UserModel;
using ServiceStack.Host;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lessons_api.Domain.Services
{
    public class StudentService : IStudentService
    {
        private readonly IUserRepository _userRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public StudentService(IUserRepository userRepository, IStudentRepository studentRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        public async Task<StudentDTO> GetStudentById(int id)
        {
            var student = await _studentRepository.GetStudentById(id);

            if (student == null)
            {
                throw new HttpException(404, "Not Found");
            }

            var studentDTO = _mapper.Map<StudentDTO>(student);

            return studentDTO;
        }

        public async Task<List<StudentDTO>> GetAllStudents()
        {
            var students = await _studentRepository.GetAllStudents();

            if (students.Count == 0)
            {
                throw new HttpException(404, "Not Found");
            }

            var studentDTOList = _mapper.Map<List<StudentDTO>>(students);

            return studentDTOList;
        }

        public async Task<AddStudentDTO> AddStudent(CreateUserDTO model)
        {
            var user = await _userRepository.GetUserById(model.UserId);

            if (user == null)
            {
                throw new HttpException(404, "Not Found");
            }

            var studentEntity = new StudentEntity() { UserId = model.UserId };
            var addedStudent = await _studentRepository.AddStudent(studentEntity);

            if (addedStudent == null)
            {
                throw new HttpException(404, "Not Found");
            }

            var addedStudentDTO = _mapper.Map<AddStudentDTO>(addedStudent);

            return addedStudentDTO;
        }

        public async Task<UpdateStudentDTO> UpdateStudent(int id, UpdateStudentDTO model)
        {
            var userEntity = _mapper.Map<UserEntity>(model);
            var updatedStudent = await _studentRepository.UpdateStudent(id, userEntity);

            if (updatedStudent == null)
            {
                throw new HttpException(404, "Not Found");
            }

            var updatedStudentDTO = _mapper.Map<UpdateStudentDTO>(updatedStudent);

            return updatedStudentDTO;
        }

        public async Task DeleteStudentById(int id)
        {
            var deletedUserId = await _studentRepository.DeleteStudentById(id);
            await _userRepository.DeleteUserById(deletedUserId);
        }
    }
}
