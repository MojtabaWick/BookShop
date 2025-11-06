namespace BookShop.Domain.UserAgg.Dtos
{
    public class UserLoginOutputDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string? Email { get; set; }
        public string Mobile { get; set; }
        public string? Username { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsActiive { get; set; }
    }
}
