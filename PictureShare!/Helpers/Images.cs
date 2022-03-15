namespace PictureShare_.Helpers
{
    public class Images
    {
        IWebHostEnvironment _env;
        public Images(IWebHostEnvironment env)
        {
            _env = env;
        }

        public async Task<string> Upload(IFormFile file, string path)
        {
            //gets the extension of an image file e.g. "PNG"
            string extension = Path.GetExtension(file.FileName);

            //gets the root of the image file e.g. "C:/..../wwwRoot/"
            string root = _env.WebRootPath;

            //combines the root and then the path of the image e.g. "C:/..../wwwRoot/Images/"
            string uploadPath = $"{root}{path}";

            //creates a new filename from a guid with the correct extension for the image, so that all images have unique names even if the same image.
            string newFilename = $"{Guid.NewGuid()}{extension}".ToLower();

            //creates the full file path
            string filePath = $"{uploadPath}{newFilename}";

            //creates the "images" folder if it is not there.
            Directory.CreateDirectory(uploadPath);

            //creates a new file stream to create a new file
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }
            return $"{path}{newFilename}";
        }

        public bool Delete(string path)
        {
            //adds the full path to the image path so it knows where to delete the file from.
            path = _env.WebRootPath + path;
            if (File.Exists(path))
            {
                File.Delete(path);
                return true;
            }
            return false;
        }


    }
}
