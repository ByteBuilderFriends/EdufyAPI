namespace EdufyAPI.Helpers
{
    public class FileUploadHelper
    {
        // Base directory for all uploads
        private static readonly string BaseUploadDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");

        // Allowed file extensions for upload
        private static readonly string[] AllowedFileExtensions = { ".jpg", ".jpeg", ".png", ".gif", ".pdf", ".docx", ".mp4", ".mov", ".avi", ".mkv" };
        // Maximum file size allowed (500 MB for videos)
        private const long MaxFileSize = 500 * 1024 * 1024;

        // Ensure the directory exists
        private static void EnsureFolderExists(string folderPath)
        {
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
        }

        // Uploads a file and returns its relative URL
        public static async Task<string> UploadFileAsync(IFormFile file, string folder)
        {
            // Validate the file
            if (file == null || file.Length == 0 || file.Length > MaxFileSize)
            {
                return null;
            }

            // Get file extension and check if it's allowed
            var fileExtension = Path.GetExtension(file.FileName).ToLower();
            if (!AllowedFileExtensions.Contains(fileExtension))
            {
                return null;
            }

            try
            {
                // Full path of the folder for the specific file type (e.g., images, videos)
                var uploadsFolder = Path.Combine(BaseUploadDirectory, folder);  //"C:\\Projects\\EdufyAPI\\wwwroot\\images"

                // Ensure the upload folder exists
                EnsureFolderExists(uploadsFolder);

                // Generate a unique file name using GUID
                var fileName = $"{Guid.NewGuid()}{fileExtension}";  // "d3c72b6d-2c2d-4f30-8a87-6b2f3f5d2331.jpg"

                // Combine the folder path and file name to get the full file path
                var filePath = Path.Combine(uploadsFolder, fileName); // "C:\\Projects\\EdufyAPI\\wwwroot\\images\\d3c72b6d-2c2d-4f30-8a87-6b2f3f5d2331.jpg"

                // Save the file to the specified path asynchronously
                /*If:
                filePath = "C:\\Projects\\EdufyAPI\\wwwroot\\images\\d3c72b6d-2c2d-4f30-8a87-6b2f3f5d2331.jpg"
                imageFile is an uploaded file from a form with a size of 2 MB

                The code:
                Creates a new file named d3c72b6d-2c2d-4f30-8a87-6b2f3f5d2331.jpg in the wwwroot/images folder.
                Asynchronously writes the contents of the uploaded image into this file.
                Automatically closes the file once the writing process is complete.
                This allows the image to be saved to the server while maintaining good application performance.*/
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                // Return the relative URL for accessing the file
                return $"/uploads/{folder}/{fileName}"; //This makes the file accessible on the web after being saved to the server.
            }
            catch (Exception ex)
            {
                // Log error if upload fails
                Console.WriteLine($"File upload failed: {ex.Message}");

                // Return null if the file could not be saved
                return null;
            }
        }

        // Deletes a file from the specified folder
        public static void DeleteFile(string fileUrl)
        {
            // Validate the file URL
            if (string.IsNullOrEmpty(fileUrl))
            {
                return;
            }

            try
            {
                // Extract the file path from the URL
                // Convert from "/uploads/images/example.jpg" to "\uploads\images\example.jpg" ,because URLs use forward slashes (/), but Windows file paths use backslashes (\).
                /* Path.DirectorySeparatorChar is a property provides the default character used to separate directories in file paths, depending on the operating system:
                On Windows: It is a backslash (\)
                On Linux and macOS: It is a forward slash(/)*/
                var relativePath = fileUrl.Replace("/", Path.DirectorySeparatorChar.ToString());
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", relativePath); //C:\Projects\EdufyAPI\wwwroot\uploads\images\example.jpg

                // Check if the file exists before attempting to delete
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
            }
            catch (Exception ex)
            {
                // Log error if deletion fails
                Console.WriteLine($"File deletion failed: {ex.Message}");
            }
        }
    }
}
