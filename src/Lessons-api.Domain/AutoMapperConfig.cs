using AutoMapper;
using Lessons_api.Data.Models;
using Lessons_api.Domain.StudentModel;
using Lessons_api.Domain.TeacherModel;

namespace Lessons_api.Domain
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<StudentDTO, StudentEntity>().ReverseMap();
            CreateMap<AddStudentDTO, StudentEntity>().ReverseMap();
            CreateMap<BaseStudentDTO, StudentEntity>().ReverseMap();
            CreateMap<UpdateStudentDTO, StudentEntity>().ReverseMap();

            CreateMap<TeacherDTO, TeacherEntity>().ReverseMap();
            CreateMap<AddTeacherDTO, TeacherEntity>().ReverseMap();
            CreateMap<BaseTeacherDTO, TeacherEntity>().ReverseMap();
            CreateMap<UpdateTeacherDTO, TeacherEntity>().ReverseMap();
        }
    }
}
