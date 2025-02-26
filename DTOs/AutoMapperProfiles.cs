﻿using AutoMapper;
using EduConnectAPI.Models;
using EdufyAPI.DTOs.CertificateDTOs;
using EdufyAPI.DTOs.CourseDTOs;
using EdufyAPI.DTOs.InstructorDTOs;
using EdufyAPI.DTOs.LessonDTOs;
using EdufyAPI.DTOs.ProgressDTOs;
using EdufyAPI.DTOs.QuizModelsDTOs.QuizDTOs;
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
            #endregion

            #region Instructor AutoMapper
            CreateMap<Instructor, InstructorReadDTO>().ReverseMap(); // Updated to use full namespace
            CreateMap<Instructor, RegisterViewModel>().ReverseMap();
            #endregion

            #region Course AutoMapper
            CreateMap<Course, CourseReadDTO>();
            CreateMap<CourseCreateDTO, Course>();
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

            #region Quiz AutoMapper
            CreateMap<Quiz, QuizReadDTO>()
                    .ForMember(dest => dest.LessonTitle, opt => opt.MapFrom(src => src.Lesson.Title));
            CreateMap<QuizCreateDTO, Quiz>();
            CreateMap<QuizUpdateDTO, Quiz>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            #endregion
        }
    }
}
