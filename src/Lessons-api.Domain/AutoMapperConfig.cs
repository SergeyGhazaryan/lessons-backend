using AutoMapper;
using Lessons_api.Data.Models;
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

            CreateMap<AddStudentDTO, StudentEntity>().ReverseMap().ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.User.FirstName))
                                                                  .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.User.LastName))
                                                                  .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.User.Country))
                                                                  .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.User.City))
                                                                  .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.User.Age));

            CreateMap<UserDTO, StudentEntity>().ReverseMap();

            CreateMap<UpdateStudentDTO, StudentEntity>().ReverseMap().ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.User.FirstName))
                                                                     .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.User.LastName))
                                                                     .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.User.Country))
                                                                     .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.User.City))
                                                                     .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.User.Age));

            CreateMap<TeacherDTO, TeacherEntity>().ReverseMap().ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.User.FirstName))
                                                               .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.User.LastName))
                                                               .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.User.Country))
                                                               .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.User.City))
                                                               .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.User.Age));

            CreateMap<AddTeacherDTO, TeacherEntity>().ReverseMap().ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.User.FirstName))
                                                                  .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.User.LastName))
                                                                  .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.User.Country))
                                                                  .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.User.City))
                                                                  .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.User.Age));

            CreateMap<UserDTO, TeacherEntity>().ReverseMap().ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.User.FirstName))
                                                            .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.User.LastName))
                                                            .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.User.Country))
                                                            .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.User.City))
                                                            .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.User.Age));

            CreateMap<UpdateTeacherDTO, TeacherEntity>().ReverseMap();

            CreateMap<AddUserDTO, UserEntity>().ReverseMap();

            CreateMap<UserDTO, UserEntity>().ReverseMap();

            CreateMap<UpdateUserDTO, UserEntity>().ReverseMap();
        }
    }
}
