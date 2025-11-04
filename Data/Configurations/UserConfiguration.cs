using BBB.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BBB.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(u => u.Id);

            builder.Property(u => u.UserName)
                   .IsRequired()
                   .HasMaxLength(128);
            builder.HasIndex(u  => u.UserName)
                   .IsUnique();

            builder.Property(u => u.Email)
                   .IsRequired()
                   .HasMaxLength(128);
            builder.HasIndex(u => u.Email)
                   .IsUnique();

            builder.HasOne(u => u.Role)
                   .WithMany(r => r.Users)
                   .HasForeignKey(u => u.RoleId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
