using AutoMapper;
using EduConnectAPI.Models;
using EdufyAPI.DTOs.CertificateDTOs;
using EdufyAPI.DTOs.StudentDTOs;
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
        }
    }
}
