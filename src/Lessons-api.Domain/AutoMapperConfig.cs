using AutoMapper;
using Lessons_api.Data.Models;
using Lessons_api.Domain.LessonModel;
using Lessons_api.Domain.StudentModel;
using Lessons_api.Domain.TeacherModel;
using Lessons_api.Domain.UserModel;

namespace Lessons_api.Domain
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<StudentDTO, StudentEntity>().ReverseMap().ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.User.FirstName))
                                                               .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.User.LastName))
                                                               .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.User.Country))
                                                               .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.User.City))
                                                               .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.User.Age));

            CreateMap<BaseUserDTO, StudentEntity>().ReverseMap().ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.User.FirstName))
                                                                  .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.User.LastName))
                                                                  .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.User.Country))
                                                                  .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.User.City))
                                                                  .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.User.Age));

            CreateMap<BaseUserDTO, StudentEntity>().ReverseMap();

            CreateMap<BaseUserDTO, StudentEntity>().ReverseMap().ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.User.FirstName))
                                                                     .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.User.LastName))
                                                                     .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.User.Country))
                                                                     .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.User.City))
                                                                     .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.User.Age));

            CreateMap<TeacherDTO, TeacherEntity>().ReverseMap().ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.User.FirstName))
                                                               .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.User.LastName))
                                                               .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.User.Country))
                                                               .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.User.City))
                                                               .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.User.Age));

            CreateMap<BaseUserDTO, TeacherEntity>().ReverseMap().ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.User.FirstName))
                                                                  .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.User.LastName))
                                                                  .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.User.Country))
                                                                  .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.User.City))
                                                                  .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.User.Age));

            CreateMap<UserDTO, UserEntity>().ReverseMap();

            CreateMap<BaseUserDTO, UserEntity>().ReverseMap();

            CreateMap<LessonDTO, LessonEntity>().ReverseMap();

            CreateMap<LessonContentDTO, LessonEntity>().ReverseMap();

            CreateMap<LessonContentDTO, LessonEntity>().ReverseMap();
        }
    }
}
