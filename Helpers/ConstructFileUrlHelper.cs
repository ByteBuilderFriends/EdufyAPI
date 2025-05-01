namespace EdufyAPI.Helpers
{
    public class ConstructFileUrlHelper
    {
        //constructs the full URL for the lesson file, allowing the frontend to display it easily
        public static string ConstructFileUrl(HttpRequest request, string folder, string fileName)
        {
            //Request.Scheme = hhtp/https - Request.Host = localhost:5000 or example.com - Path.GetFileName(lesson.ThumbnailUrl) = Example: image1.jpg
            //For example: https://localhost:5000/lesson-thumbnails/image1.jpg
            return $"{request.Scheme}://{request.Host}/uploads/{folder}/{Path.GetFileName(fileName)}";
        }
    }
}
