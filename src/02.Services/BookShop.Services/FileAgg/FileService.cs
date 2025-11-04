using BookShop.Domain.FileAgg.Contracts;
using Microsoft.AspNetCore.Http;

namespace BookShop.Services.FileAgg
{
    public class FileService : IFileService
    {
        public string Upload(IFormFile file)
        {

            var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images");

            if (!Directory.Exists(uploadsFolder))
                Directory.CreateDirectory(uploadsFolder);

            var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

            var filePath = Path.Combine(uploadsFolder, uniqueFileName);


            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            return $"{Path.Combine("Images", uniqueFileName)}";
        }
    }
}
