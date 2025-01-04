using Demo.Models;
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

    }
}
