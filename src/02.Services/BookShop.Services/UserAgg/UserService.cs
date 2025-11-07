using BookShop.Domain._common;
using BookShop.Domain.UserAgg.Contracts;
using BookShop.Domain.UserAgg.Dtos;
using BookShop.Framework;

namespace BookShop.Services.UserAgg
{
    public class UserService(IUserRepository userRepository) : IUserService
    {
        public List<GetUserSummaryDto> GetUsersSummary()
        {
            var users = userRepository.GetUsersSummary();
            return users;
        }
        public void Active(int userId)
         => userRepository.Active(userId);

        public void DeActive(int userId)
         => userRepository.DeActive(userId);

        public void Delete(int userId)
         => userRepository.Delete(userId);


        public Result<UserLoginOutputDto> Login(string mobileOrUsername, string password)
        {
            var login = userRepository.Login(mobileOrUsername, password.ToMd5Hex());

            if (login is not null)
            {
                var isActive = userRepository.IsActive(mobileOrUsername);

                return isActive
                    ? Result<UserLoginOutputDto>.Success("لاگین با موفقیت انجام شد.", login)
                    : Result<UserLoginOutputDto>.Failure("کاربر با این شماره فعال نمی‌باشد.");
            }
            else
            {
                return Result<UserLoginOutputDto>.Failure("نام کاربری یا کلمه عبور اشتباه می باشد.");
            }
        }
        public Result<bool> Register(RegisterUserInputDto model)
        {
            var mobileExist = userRepository.MobileExists(model.PhoneNumber);

            if (mobileExist)
            {
                return Result<bool>.Failure("کاربر با این شماره موجود می باشد.");
            }

            model.Password = model.Password.ToMd5Hex();

            userRepository.Register(model);

            return Result<bool>.Success("ثبت نام با موفقیت انجام شد.");
        }
        public UpdateGetUserDto GetUpdateUserDetails(int userId)
        {
            var user = userRepository.GetUpdateUserDetails(userId);
            return user;
        }

        public Result<bool> Update(int userId, UpdateGetUserDto model)
        {

            if (model.Password is not null)
            {
                model.Password = model.Password.ToMd5Hex();
            }

            var result = userRepository.Update(userId, model);

            if (result)
            {
                return Result<bool>.Success("اطلاعات کاربر با موفقیت به‌روزرسانی شد.");
            }
            else
            {
                return Result<bool>.Failure("به‌روزرسانی اطلاعات کاربر با خطا مواجه شد.");
            }
        }
    }
}
