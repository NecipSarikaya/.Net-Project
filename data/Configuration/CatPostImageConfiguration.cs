using entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace data.Configuration
{
    public class CatPostImageConfiguration : IEntityTypeConfiguration<CatPostImage>
    {
        public void Configure(EntityTypeBuilder<CatPostImage> builder)
        {
            builder.HasKey(l => new {l.CatPostId,l.ImageUrl});
            builder.Property( l => l.ImageUrl).HasMaxLength(120).IsRequired();
        }
    }
}