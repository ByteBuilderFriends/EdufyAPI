namespace EdufyAPI.DTOs.StudentDTOs
{
    public class GetStudentCoursesDTO
    {
        public string StudentId { get; set; }

        //public Dictionary<string, string> Courses { get; set; }

        public List<CourseReadByIdDTO> courses { get; set; } = new List<CourseReadByIdDTO>();

        //public List<string> CoursesTitle { get; set; } = new List<string>();

    }
}
