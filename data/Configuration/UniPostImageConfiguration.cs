using entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace data.Configuration
{
    public class UniPostImageConfiguration : IEntityTypeConfiguration<UniPostImage>
    {
        public void Configure(EntityTypeBuilder<UniPostImage> builder)
        {
            builder.HasKey( l => new{l.ImageUrl,l.UniPostId});
            builder.Property(l => l.ImageUrl).HasMaxLength(250).IsRequired();
        }
    }
}