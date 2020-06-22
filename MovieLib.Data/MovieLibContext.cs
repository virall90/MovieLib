using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MovieLib.Data.Models;

namespace MovieLib.Data
{
    public class MovieLibContext : IdentityDbContext<User>
    {
        public MovieLibContext(DbContextOptions options) : base(options)
        {
            base.Database.EnsureCreated();
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(MovieLibContext).Assembly);
        }

        /// <summary> Фильмы </summary>
        public DbSet<Movie> Movies { get; set; }

        /// <summary> Токены API пользователей </summary>
        public DbSet<UserApiToken> UserApiTokens { get; set; }
    }
}