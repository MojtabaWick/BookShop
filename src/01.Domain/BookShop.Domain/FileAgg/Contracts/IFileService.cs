using Microsoft.AspNetCore.Http;

namespace BookShop.Domain.FileAgg.Contracts
{
    public interface IFileService
    {
        public string Upload(IFormFile file);
    }
}
