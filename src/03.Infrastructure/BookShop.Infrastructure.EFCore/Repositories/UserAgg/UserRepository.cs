using BookShop.Domain.UserAgg.Contracts;
using BookShop.Domain.UserAgg.Dtos;
using BookShop.Domain.UserAgg.Entities;
using BookShop.Infrastructure.EFCore.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BookShop.Infrastructure.EFCore.Repositories.UserAgg
{
    public class UserRepository(AppDbContext dbContext) : IUserRepository
    {
        public List<GetUserSummaryDto> GetUsersSummary()
        {
            var user = dbContext.Users
            .Select(u => new GetUserSummaryDto
            {
                Id = u.Id,
                Username = u.Username,
                Email = u.Email,
                Mobile = u.PhoneNumber,
                FirstName = u.FirstName,
                LastName = u.LastName,
                IsAdmin = u.IsAdmin,
                IsActive = u.IsActive,

            }).ToList();

            return user;
        }
        public void Active(int userId)
        {
            dbContext.Users
                        .Where(u => u.Id == userId)
                        .ExecuteUpdate(setters => setters
                        .SetProperty(u => u.IsActive, true));
        }

        public void DeActive(int userId)
        {
            dbContext.Users
                        .Where(u => u.Id == userId)
                        .ExecuteUpdate(setters => setters
                        .SetProperty(u => u.IsActive, false));
        }
        public void Delete(int userId)
        {
            dbContext.Users
                .Where(u => u.Id == userId)
                .ExecuteDelete();
        }
        public bool IsActive(string MobileOrUsername)
        {
            return dbContext.Users.Any(u => (u.PhoneNumber == MobileOrUsername || u.Username == MobileOrUsername) && u.IsActive);
        }
        public bool MobileExists(string PhoneNumber)
        {
            return dbContext.Users.Any(u => u.PhoneNumber == PhoneNumber);
        }
        public UserLoginOutputDto? Login(string mobileOrUsername, string password)
        {
            var user = dbContext.Users
            .Where(u => (u.PhoneNumber == mobileOrUsername || u.Username == mobileOrUsername) && u.PasswordHash == password)
            .Select(u => new UserLoginOutputDto
            {
                Id = u.Id,
                Username = u.Username,
                Email = u.Email,
                Mobile = u.PhoneNumber,
                FullName = u.FirstName + " " + u.LastName,
                IsAdmin = u.IsAdmin,
                IsActiive = u.IsActive,
            }).AsEnumerable().FirstOrDefault();

            return user;
        }
        public bool Register(RegisterUserInputDto model)
        {
            var entity = new User
            {
                PhoneNumber = model.PhoneNumber,
                Username = model.Username,
                PasswordHash = model.Password,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                IsAdmin = model.IsAdmin,
            };

            dbContext.Users.Add(entity);
            return dbContext.SaveChanges() > 1;
        }
    }
}
