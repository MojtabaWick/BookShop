using BookShop.Domain.CategoryAgg.Entities;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookShop.Domain.BookAgg.Enitities
{
    public class Book
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Author { get; set; }
        public int Price { get; set; }
        public int PageCount { get; set; }
        public string ImageUrl { get; set; }

        [NotMapped]
        public IFormFile? File { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
    }
}
