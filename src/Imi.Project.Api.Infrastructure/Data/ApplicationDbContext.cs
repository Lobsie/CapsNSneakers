using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Infrastructure.Data.Configuration;
using Imi.Project.Api.Infrastructure.Data.Seeding;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Imi.Project.Api.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Fitting> Fittings { get; set; }
        public DbSet<Cap> Caps { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Add Seeding
            BrandsSeeder.Seed(modelBuilder);
            FittingsSeeder.Seed(modelBuilder);
            CapsSeeder.Seed(modelBuilder);
            UserSeeder.Seed(modelBuilder);

            // Add configurations and seeding for configured
            UserCapConfiguration.Configure(modelBuilder);
        }
    }
}