using BookShop.Domain._common;
using BookShop.Domain.UserAgg.Dtos;

namespace BookShop.Domain.UserAgg.Contracts
{
    public interface IUserService
    {
        public List<GetUserSummaryDto> GetUsersSummary();
        public void Active(int userId);
        public void DeActive(int userId);
        public void Delete(int userId);
        public Result<UserLoginOutputDto> Login(string mobileOrUsername, string password);
        public Result<bool> Register(RegisterUserInputDto model);
        public Result<bool> Update(int userId, UpdateGetUserDto model);
        public UpdateGetUserDto GetUpdateUserDetails(int userId);
    }
}
