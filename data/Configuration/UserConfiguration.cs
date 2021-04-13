using entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace data.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(l => l.Id);
            builder.Property(l => l.Name).HasMaxLength(35).IsRequired();
            builder.Property(l => l.LastName).HasMaxLength(35).IsRequired();
            builder.Property(l => l.Gender).HasMaxLength(35);
            builder.Property(l => l.ImageUrl).HasMaxLength(120);
            builder.Property(l => l.InstagramLink).HasMaxLength(120);
            builder.Property(l => l.TwitterLink).HasMaxLength(120);
            builder.Property(l => l.About).HasMaxLength(250);
        }
    }
}