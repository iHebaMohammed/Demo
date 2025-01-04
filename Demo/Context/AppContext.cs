using Demo.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Demo.Context
{
    public class AppContextDb : IdentityDbContext<ApplicationUser>
    {
        public AppContextDb(DbContextOptions<IdentityDbContext> options) : base(options)
        {
        }

        public AppContextDb()
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=.; Database=DemoDb; Trusted_Connection=True; TrustServerCertificate=True; MultipleActiveResultSets=True");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityRole>().HasData(
               new IdentityRole { Id = Guid.NewGuid().ToString(), Name = "Admin", NormalizedName = "ADMIN" },
               new IdentityRole { Id = Guid.NewGuid().ToString(), Name = "User", NormalizedName = "USER" }
           );

            // Seed default application user data (if needed)
            // Note: You can seed simple users here but typically it's done at runtime
            // so that you can use UserManager and other services.
            builder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "admin@example.com",
                    DisplayName = "ADMIN",
                    Email = "admin@example.com",
                    NormalizedUserName = "ADMIN@EXAMPLE.COM",
                    NormalizedEmail = "ADMIN@EXAMPLE.COM",
                    EmailConfirmed = true,
                    PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(null, "P@$$w0rd")
                }
            );
        }
    }
}
