using AutoMapper;
using Lessons_api.Data.Interfaces;
using Lessons_api.Data.Models;
using Lessons_api.Domain.Interfaces;
using Lessons_api.Domain.StudentModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lessons_api.Domain.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public StudentService(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        public async Task<StudentDTO> GetStudentById(int id)
        {
            var student = await _studentRepository.GetStudentById(id);

            return _mapper.Map<StudentDTO>(student);
        }

        public async Task<List<StudentDTO>> GetAllStudents()
        {
            var students = await _studentRepository.GetAllStudents();

            return _mapper.Map<List<StudentDTO>>(students);
        }

        public async Task<AddStudentDTO> AddStudent(AddStudentDTO model)
        {
            var studentEntity = new StudentEntity() { FirstName = model.FirstName, LastName = model.LastName, Country = model.Country, City = model.City, Age = model.Age };
            var addedStudent = await _studentRepository.AddStudent(studentEntity);

            return _mapper.Map<AddStudentDTO>(addedStudent);
        }

        public async Task<UpdateStudentDTO> UpdateStudent(int id, UpdateStudentDTO model)
        {
            var studentEntity = new StudentEntity() { FirstName = model.FirstName, LastName = model.LastName, Country = model.Country, City = model.City, Age = model.Age };
            var updatedStudent = await _studentRepository.UpdateStudent(id, studentEntity);

            return _mapper.Map<UpdateStudentDTO>(updatedStudent);
        }

        public async Task DeleteStudentById(int id)
        {
            await _studentRepository.DeleteStudentById(id);
        }
    }
}
