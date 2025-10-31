using BBB.Data.Configurations;
using BBB.Models;
using Microsoft.EntityFrameworkCore;

namespace BBB.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<User> Users => Set<User>();
        public DbSet<Role> Roles => Set<Role>();
        public DbSet<Auth> Auths => Set<Auth>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new AuthConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
