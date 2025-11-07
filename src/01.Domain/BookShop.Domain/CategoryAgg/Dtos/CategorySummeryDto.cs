namespace BookShop.Domain.CategoryAgg.Dtos
{
    public class CategorySummeryDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? ImgAddress { get; set; }
        public int BooksCount { get; set; }
    }
}
