using BookShop.Domain.UserAgg.Entities;
using BookShop.Framework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookShop.Infrastructure.EFCore.Configurations
{
    public class UserConfigurations : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(u => u.LastName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(u => u.Email)
                .HasMaxLength(100);

            builder.Property(u => u.PasswordHash)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(u => u.Username)
                .HasMaxLength(50);

            builder.Property(u => u.Address)
                .HasMaxLength(250);

            builder.Property(u => u.PhoneNumber)
                .HasMaxLength(20);

            builder.HasData(
                new User
                {
                    Id = 1,
                    FirstName = "Admin",
                    LastName = "User",
                    PhoneNumber = "09128030353",
                    PasswordHash = "1234".ToMd5Hex(),
                    IsAdmin = true,
                    IsActive = true,
                }
            );

            builder.Property(u => u.IsActive)
            .HasConversion(
                v => v ? "Yes" : "No",  
                v => v == "Yes"         
            )
            .HasColumnType("nvarchar(3)")
            .HasMaxLength(3)
            .IsRequired();

            builder.Property(u => u.IsAdmin)
            .HasConversion(
                v => v ? "Yes" : "No",  
                v => v == "Yes"         
            )
            .HasColumnType("nvarchar(3)")
            .HasMaxLength(3)
            .IsRequired();

        }
    }
}
