using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieLib.Data.Models;

namespace MovieLib.Data.Configurations
{
    public class UserApiTokenConfiguration : IEntityTypeConfiguration<UserApiToken>
    {
        public void Configure(EntityTypeBuilder<UserApiToken> builder)
        {
            builder.HasKey(x => new {x.UserId, x.ApiToken});

            builder
                .HasOne(x => x.User)
                .WithMany(x => x.ApiTokens)
                .HasForeignKey(x => x.UserId);
        }
    }
}