using AutoMapper;
using EduConnectAPI.Models;
using EdufyAPI.DTOs.CertificateDTOs;
using EdufyAPI.DTOs.CourseDTOs;
using EdufyAPI.DTOs.StudentDTOs;
using EdufyAPI.Models;
using EdufyAPI.Models.Roles;

namespace EdufyAPI.DTOs
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Certificate, GetCertificateDTO>(); // Map GenerateStudentCertificateDTO to Certificate
            CreateMap<GetCertificateDTO, Certificate>();

            CreateMap<CreateStudentDTO, Student>(); // Map CreateStudentDTO to Student
            CreateMap<Student, CreateStudentDTO>();

            //It checks if the Instructor is not null.
            //If true, it concatenates FirstName and LastName with a space in between.
            //If Instructor is null, it sets InstructorName to "Unknown".
            CreateMap<Course, CourseReadDTO>()
                .ForMember(dest => dest.InstructorName,
                           opt => opt.MapFrom(src =>
                               src.Instructor != null
                               ? $"{src.Instructor.FirstName} {src.Instructor.LastName}"
                               : "Unknown"));
            CreateMap<CourseCreateDTO, Course>();
            CreateMap<CourseUpdateDTO, Course>();
        }
    }
}
