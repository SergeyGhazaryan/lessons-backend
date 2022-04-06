using AutoMapper;
using Lessons_api.Data.Interfaces;
using Lessons_api.Data.Models;
using Lessons_api.Domain.Interfaces;
using Lessons_api.Domain.LessonModel;
using ServiceStack.Host;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lessons_api.Domain.Services
{
    public class LessonService : ILessonService
    {
        private readonly ILessonRepository _lessonRepository;
        private readonly ITeacherRepository _teacherRepository;
        private readonly IMapper _mapper;

        public LessonService(ILessonRepository lessonRepository, ITeacherRepository teacherRepository, IMapper mapper)
        {
            _lessonRepository = lessonRepository;
            _teacherRepository = teacherRepository;
            _mapper = mapper;
        }

        public async Task<LessonDTO> GetLessonById(int id)
        {
            var lesson = await _lessonRepository.GetLessonById(id);

            if (lesson == null)
            {
                throw new HttpException(404, "Not Found");
            }

            var lessonDTO = _mapper.Map<LessonDTO>(lesson);

            return lessonDTO;
        }

        public async Task<List<LessonDTO>> GetLessonsByTeacherId(int teacherId)
        {
            var teacher = await _teacherRepository.GetTeacherById(teacherId);

            if (teacher == null)
            {
                throw new HttpException(404, "Not Found");
            }

            var lessons = await _lessonRepository.GetLessonsByTeacherId(teacherId);

            if (lessons == null)
            {
                throw new HttpException(404, "Not Found");
            }

            var lessonDTO = _mapper.Map<List<LessonDTO>>(lessons);

            return lessonDTO;
        }

        public async Task<List<LessonDTO>> GetAllLessons()
        {
            var lessons = await _lessonRepository.GetAllLessons();

            if (!lessons.Any())
            {
                throw new HttpException(404, "Not Found");
            }

            var lessonDTOList = _mapper.Map<List<LessonDTO>>(lessons);

            return lessonDTOList;
        }

        public async Task<LessonContentDTO> CreateLesson(int teacherId, LessonContentDTO model)
        {
            var teacher = await _teacherRepository.GetTeacherById(teacherId);

            if (teacher == null)
            {
                throw new HttpException(404, "Not Found");
            }

            var lessonEntity = new LessonEntity() { TeacherId = teacherId, Title = model.Title, Description = model.Description, Price = model.Price, Language = model.Language };
            var createdLesson = await _lessonRepository.CreateLesson(lessonEntity);

            if (createdLesson == null)
            {
                throw new HttpException(404, "Not Found");
            }

            var createdLessonDTO = _mapper.Map<LessonContentDTO>(createdLesson);

            return createdLessonDTO;
        }

        public async Task<LessonContentDTO> UpdateLesson(int teacherId, int lessonId, LessonContentDTO model)
        {
            var teacher = await _teacherRepository.GetTeacherById(teacherId);

            if (teacher == null)
            {
                throw new HttpException(404, "Not Found");
            }

            var lessonEntity = new LessonEntity() { Title = model.Title, Description = model.Description, Price = model.Price, Language = model.Language };
            var updatedLesson = await _lessonRepository.UpdateLesson(teacherId, lessonId, lessonEntity);

            if (updatedLesson == null)
            {
                throw new HttpException(404, "Not Found");
            }

            var updatedLessonDTO = _mapper.Map<LessonContentDTO>(updatedLesson);

            return updatedLessonDTO;
        }

        public async Task DeleteLessonByTeacherId(int id, int teacherId)
        {
            await _lessonRepository.DeleteLessonByTeacherId(id, teacherId);
        }
    }
}
