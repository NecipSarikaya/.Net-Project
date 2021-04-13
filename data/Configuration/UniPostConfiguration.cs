using entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace data.Configuration
{
    public class UniPostConfiguration : IEntityTypeConfiguration<UniPost>
    {
        public void Configure(EntityTypeBuilder<UniPost> builder)
        {
            builder.HasKey(l => l.Id);
            builder.Property(l =>l.PublishDate).HasDefaultValueSql("getdate()");
            builder.Property(l =>l.Title).HasMaxLength(100).IsRequired();
            builder.Property(l =>l.Content).HasMaxLength(250).IsRequired();
        }
    }
}