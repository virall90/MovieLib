using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieLib.Data.Models;

namespace MovieLib.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(
                new User
                {
                    Id = "daab329d-18a7-40cd-b3bf-4681d1949248",
                    UserName = "buddy",
                    NormalizedUserName = "BUDDY",
                    Email = "buddy@test.ru",
                    NormalizedEmail = "BUDDY@TEST.RU",
                    EmailConfirmed = false,
                    PasswordHash =
                        "AQAAAAEAACcQAAAAEGxXEgNHGoqkIi/67eLJrP6+I27KnrqCCTfZ12/EHtg4x5uVpGhtzCjIVcVdtnsJmw==",
                    SecurityStamp = "UHYWSO25LABVTIEBDFWUWH4U3OQRZNH3",
                    ConcurrencyStamp = "e002d192-90d1-4edb-83dd-d9cdd82dfa35",
                    PhoneNumber = null,
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnd = null,
                    LockoutEnabled = true,
                    AccessFailedCount = 0,
                },
                new User
                {
                    Id = "ec6439fb-f16d-4c30-9e64-13cb23ca6455",
                    UserName = "john",
                    NormalizedUserName = "JOHN",
                    Email = "john@test.ru",
                    NormalizedEmail = "JOHN@TEST.RU",
                    EmailConfirmed = false,
                    PasswordHash =
                        "AQAAAAEAACcQAAAAEIo94ryl21yw8hGPwIpZ0g4tKvAK/61WbkHvfmkxql06zNOEzaXvhdE7smhod1T4XQ==",
                    SecurityStamp = "7GIAKTTYVJPRIG5LZCHWKW7GPYRTW3UD",
                    ConcurrencyStamp = "e6863dcf-3ec3-4894-80ad-0bb0f464822c",
                    PhoneNumber = null,
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnd = null,
                    LockoutEnabled = true,
                    AccessFailedCount = 0,
                });
        }
    }
}