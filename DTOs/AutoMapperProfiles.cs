using AutoMapper;
using EduConnectAPI.Models;
using EdufyAPI.DTOs.CertificateDTOs;
using EdufyAPI.DTOs.CourseDTOs;
using EdufyAPI.DTOs.EnrollmentDTOs;
using EdufyAPI.DTOs.InstructorDTOs;
using EdufyAPI.DTOs.LessonDTOs;
using EdufyAPI.DTOs.ProgressDTOs;
using EdufyAPI.DTOs.StudentCourseDTOs;
using EdufyAPI.DTOs.StudentDTOs;
using EdufyAPI.Models;
using EdufyAPI.Models.Roles;
using EdufyAPI.ViewModels;

namespace EdufyAPI.DTOs
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            //The Recommended order for AutoMapper configurations, in terms of Entity and DTO is:
            //Entity → ReadDTO: Because you're reading data from the database to send to the client.
            //CreateDTO → Entity: Because you receive data from the client and map it to a new entity to save in the database.
            //UpdateDTO → Entity: Because you receive updated data from the client to modify an existing entity.

            #region Certificate AutoMapper
            CreateMap<Certificate, GetCertificateDTO>(); // Map GenerateStudentCertificateDTO to Certificate
            CreateMap<GetCertificateDTO, Certificate>();
            #endregion

            #region Student AutoMapper
            //Registeration of Student to StudentReadDTO
            CreateMap<Student, RegisterViewModel>().ReverseMap();
            CreateMap<Student, GetStudentsDTO>().ReverseMap();

            CreateMap<Student, GetStudentsDTO>()
                .ForMember(dest => dest.EnrolledCourses, opt => opt.MapFrom(src =>
                    src.Enrollments.Select(sc => $"{sc.Course.Title}, {sc.Course.Description}").ToList())) // ✅ Only map course titles

                .ForMember(dest => dest.CompletedCourses, opt => opt.MapFrom(src =>
                    src.Enrollments
                        .Where(sc => sc.Course.CourseProgress.All(y => y.IsCompleted))
                        .Select(sc => sc.Course.Title)
                        .ToList())) // ✅ Only completed courses

                .ForMember(dest => dest.CourseCount, opt => opt.MapFrom(src => src.Enrollments.Count))

                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}")); // ✅ Map FullName

            #endregion

            #region Instructor AutoMapper
            CreateMap<Instructor, InstructorReadDTO>().ReverseMap(); // Updated to use full namespace
            CreateMap<Instructor, RegisterViewModel>().ReverseMap();

            CreateMap<Instructor, InstructorReadDTO>()
                        .ForMember(dest => dest.Courses, opt => opt.MapFrom(src =>
                            src.Courses.Select(c => $"{c.Title}: {c.Description}").ToList()))
                        .ForMember(dest => dest.CourseCount, opt => opt.MapFrom(src => src.Courses.Count));

            #endregion

            #region Course AutoMapper
            CreateMap<Course, CourseReadDTO>()
                 .ForMember(dest => dest.NumberOfStudentsEnrolled, opt => opt.MapFrom(src => src.NumberOfStudentsEnrolled)); CreateMap<CourseCreateDTO, Course>();
            CreateMap<CourseUpdateDTO, Course>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null)); //This ensures only non-null properties are mapped, preventing overwriting existing values with null.


            #endregion

            #region Lesson AutoMapper
            CreateMap<Lesson, LessonReadDTO>();
            CreateMap<LessonCreateDTO, Lesson>();
            CreateMap<LessonUpdateDTO, Lesson>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            #endregion

            #region Progress AutoMapper
            CreateMap<Progress, ProgressReadDTO>();
            CreateMap<ProgressCreateDTO, Progress>();
            CreateMap<ProgressUpdateDTO, Progress>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            #endregion

            #region Enrollment AutoMapper
            CreateMap<Enrollment, EnrollmentReadDTO>()
                .ForMember(dest => dest.StudentName, opt => opt.MapFrom(src => src.Student.FullName))
                .ForMember(dest => dest.CourseTitle, opt => opt.MapFrom(src => src.Course.Title));
            CreateMap<EnrollmentCreateDTO, Enrollment>();
            #endregion
        }
    }
}
