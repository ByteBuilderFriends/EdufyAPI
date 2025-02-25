namespace EdufyAPI.Helpers
{
    public static class ImageHelper
    {
        public static async Task<string> SaveImageAsync(IFormFile imageFile, string folder)
        {
            if (imageFile == null || imageFile.Length == 0)
            {
                return null;
            }

            var uploadsFolder = Path.Combine("wwwroot", folder);
            Directory.CreateDirectory(uploadsFolder);

            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
            var filePath = Path.Combine(uploadsFolder, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(stream);
            }

            return $"/{folder}/{fileName}";
        }

        public static void DeleteImage(string imageUrl, string folderName)
        {
            if (string.IsNullOrEmpty(imageUrl) || string.IsNullOrEmpty(folderName))
            {
                return;
            }

            // Get the relative path by removing the base URL
            var fileName = Path.GetFileName(imageUrl);
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", folderName, fileName);

            // Check if the file exists and delete it
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }
    }
}
