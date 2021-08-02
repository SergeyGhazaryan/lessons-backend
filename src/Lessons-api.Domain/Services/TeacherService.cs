using AutoMapper;
using Lessons_api.Data.Interfaces;
using Lessons_api.Data.Models;
using Lessons_api.Domain.Interfaces;
using Lessons_api.Domain.TeacherModel;
using ServiceStack.Host;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lessons_api.Domain.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly IMapper _mapper;

        public TeacherService(ITeacherRepository teacherRepository, IMapper mapper)
        {
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

            if (teachers == null)
            {
                throw new HttpException(404, "Not Found");
            }

            var teacherDTOList = _mapper.Map<List<TeacherDTO>>(teachers);

            return teacherDTOList;
        }

        public async Task<AddTeacherDTO> AddTeacher(AddTeacherDTO model)
        {
            var teacherEntity = new TeacherEntity() { FirstName = model.FirstName, LastName = model.LastName, Country = model.Country, City = model.City, Age = model.Age };
            var addedTeacher = await _teacherRepository.AddTeacher(teacherEntity);

            if (addedTeacher == null)
            {
                throw new HttpException(404, "Not Found");
            }

            var addedTeacherDTO = _mapper.Map<AddTeacherDTO>(addedTeacher);

            return addedTeacherDTO;
        }

        public async Task<UpdateTeacherDTO> UpdateTeacher(int id, UpdateTeacherDTO model)
        {
            var teacherEntity = new TeacherEntity() { FirstName = model.FirstName, LastName = model.LastName, Country = model.Country, City = model.City, Age = model.Age };
            var updatedTeacher = await _teacherRepository.UpdateTeacher(id, teacherEntity);

            if (updatedTeacher == null)
            {
                throw new HttpException(404, "Not Found");
            }

            var updatedTeacherDTO = _mapper.Map<UpdateTeacherDTO>(updatedTeacher);

            return updatedTeacherDTO;
        }

        public async Task DeleteTeacherById(int id)
        {
            await _teacherRepository.DeleteTeacherById(id);
        }
    }
}
