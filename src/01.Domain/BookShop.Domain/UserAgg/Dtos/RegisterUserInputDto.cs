namespace BookShop.Domain.UserAgg.Dtos
{
    public class RegisterUserInputDto
    {
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string? Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Email { get; set; }
        public bool IsAdmin { get; set; }

    }
}
