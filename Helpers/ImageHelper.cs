namespace EdufyAPI.Helpers
{
    public static class ImageHelper
    {
        // Ensures the folder exists, creating it if necessary
        private static void EnsureFolderExists(string folderPath)
        {
            // Check if the folder path does not exist
            if (!Directory.Exists(folderPath))
            {
                // Create the folder
                Directory.CreateDirectory(folderPath);
            }
        }

        // Save an image and return its URL
        public static async Task<string> SaveImageAsync(IFormFile imageFile, string folder)
        {
            // Check if the image file is null or empty
            if (imageFile == null || imageFile.Length == 0)
            {
                return null;
            }

            try
            {
                // Get the full path of the upload folder
                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", folder); // "C:\\Projects\\EdufyAPI\\wwwroot\\images"

                // Ensure the upload folder exists
                EnsureFolderExists(uploadsFolder);

                // Generate a unique file name using GUID
                var fileName = $"{Guid.NewGuid()}{Path.GetExtension(imageFile.FileName)}";  // "d3c72b6d-2c2d-4f30-8a87-6b2f3f5d2331.jpg"

                // Combine the folder path and file name to get the full file path
                var filePath = Path.Combine(uploadsFolder, fileName);   // "C:\\Projects\\EdufyAPI\\wwwroot\\images\\d3c72b6d-2c2d-4f30-8a87-6b2f3f5d2331.jpg"

                // Save the file to the specified path
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
                    await imageFile.CopyToAsync(stream);
                }

                // Return the relative URL of the saved image
                return $"/{folder}/{fileName}"; //This makes the image accessible on the web after being saved to the server.
            }
            catch (Exception ex)
            {
                // Log the exception (optional)
                Console.WriteLine($"Image saving failed: {ex.Message}");

                // Return null if the image could not be saved
                return null;
            }
        }

        // Deletes an image from the specified folder
        public static void DeleteImage(string imageUrl, string folderName)
        {
            // Check if the image URL or folder name is null or empty
            if (string.IsNullOrEmpty(imageUrl) || string.IsNullOrEmpty(folderName))
            {
                return;
            }

            try
            {
                // Extract the file name from the image URL
                var fileName = Path.GetFileName(imageUrl);

                // Get the full file path of the image to be deleted
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", folderName, fileName);

                // Check if the file exists
                if (File.Exists(filePath))
                {
                    // Delete the file
                    File.Delete(filePath);
                }
            }
            catch (Exception ex)
            {
                // Log the exception (optional)
                Console.WriteLine($"Image deletion failed: {ex.Message}");
            }
        }
    }
}