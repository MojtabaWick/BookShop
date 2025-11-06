using BookShop.Domain.UserAgg.Dtos;

namespace BookShop.Domain.UserAgg.Contracts
{
    public interface IUserRepository
    {
        public List<GetUserSummaryDto> GetUsersSummary();
        public void Active(int userId);
        public void DeActive(int userId);
        public void Delete(int userId);
        public bool IsActive(string PhoneNumber);
        public bool MobileExists(string PhoneNumber);
        public UpdateGetUserDto GetUpdateUserDetails(int userId);
        public bool Update(int userId, UpdateGetUserDto model);
        public UserLoginOutputDto? Login(string mobileOrUsername, string password);
        public bool Register(RegisterUserInputDto model);

    }
}
