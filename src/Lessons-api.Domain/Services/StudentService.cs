using AutoMapper;
using Lessons_api.Data.Interfaces;
using Lessons_api.Data.Models;
using Lessons_api.Domain.Interfaces;
using Lessons_api.Domain.StudentModel;
using ServiceStack.Host;
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

            if (students == null)
            {
                throw new HttpException(404, "Not Found");
            }

            var studentDTOList = _mapper.Map<List<StudentDTO>>(students);

            return studentDTOList;
        }

        public async Task<AddStudentDTO> AddStudent(AddStudentDTO model)
        {
            var studentEntity = new StudentEntity() { FirstName = model.FirstName, LastName = model.LastName, Country = model.Country, City = model.City, Age = model.Age };
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
            var studentEntity = new StudentEntity() { FirstName = model.FirstName, LastName = model.LastName, Country = model.Country, City = model.City, Age = model.Age };
            var updatedStudent = await _studentRepository.UpdateStudent(id, studentEntity);

            if (updatedStudent == null)
            {
                throw new HttpException(404, "Not Found");
            }

            var updatedStudentDTO = _mapper.Map<UpdateStudentDTO>(updatedStudent);

            return updatedStudentDTO;
        }

        public async Task DeleteStudentById(int id)
        {
            await _studentRepository.DeleteStudentById(id);
        }
    }
}
