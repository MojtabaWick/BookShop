namespace BookShop.Presentation.MVC.Models.ViewModels
{
    public class RegisterViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mobile { get; set; }
        public string? Username { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
    }
}
