namespace EdufyAPI.Helpers
{
    public class FileUploadHelper
    {
        private static readonly string BaseUploadDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");

        private static readonly string[] AllowedFileExtensions = [".jpg", ".jpeg", ".png", ".gif", ".pdf", ".docx", ".mp4", ".mov", ".avi", ".mkv"];
        private const long MaxFileSize = 500 * 1024 * 1024;

        // Ensure the directory exists
        private static void EnsureFolderExists(string folderPath)
        {
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
        }

        public static async Task<string> UploadFileAsync(IFormFile file, string folder)
        {
            if (file == null || file.Length == 0 || file.Length > MaxFileSize)
            {
                return null;
            }

            var fileExtension = Path.GetExtension(file.FileName).ToLower();
            if (!AllowedFileExtensions.Contains(fileExtension))
            {
                return null;
            }

            try
            {
                var uploadsFolder = Path.Combine(BaseUploadDirectory, folder);

                EnsureFolderExists(uploadsFolder);

                var fileName = $"{Guid.NewGuid()}{fileExtension}";

                var filePath = Path.Combine(uploadsFolder, fileName);


                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                return $"/uploads/{folder}/{fileName}";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"File upload failed: {ex.Message}");

                return null;
            }
        }

        public static void DeleteFile(string fileUrl)
        {
            if (string.IsNullOrEmpty(fileUrl))
            {
                return;
            }

            try
            {

                var relativePath = fileUrl.Replace("/", Path.DirectorySeparatorChar.ToString());
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", relativePath); // "C:\Projects\EdufyAPI\wwwroot\uploads\images\example.jpg"

                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"File deletion failed: {ex.Message}");
            }
        }
    }
}
