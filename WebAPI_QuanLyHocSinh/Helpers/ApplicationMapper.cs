using WebAPI_QuanLyHocSinh.Dto;
using WebAPI_QuanLyHocSinh.Context;
using AutoMapper;

namespace WebAPI_QuanLyHocSinh.Helpers
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper() 
        {
            CreateMap<Student, StudentDto>().ReverseMap();
            CreateMap<Course, CourseDto>().ReverseMap();
            CreateMap<Class, ClassDto>().ReverseMap();
            CreateMap<Subject, SubjectDto>().ReverseMap();
            CreateMap<Result, ResultDto>().ReverseMap();
        }
    }
}
