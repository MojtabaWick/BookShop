using Microsoft.AspNetCore.Http;

namespace BookShop.Domain.CategoryAgg.Dtos
{
    public class UpdateGetCategoryDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? ImgAddress { get; set; }
        public IFormFile? Img { get; set; }
    }
}
