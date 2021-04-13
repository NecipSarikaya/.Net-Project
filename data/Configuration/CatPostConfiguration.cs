using entity;
using Microsoft.EntityFrameworkCore;

namespace data.Configuration
{
    public class CatPostConfiguration: IEntityTypeConfiguration<CatPost>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<CatPost> builder)
        {
            builder.HasKey(l => l.Id);
            builder.Property(l => l.Title).HasMaxLength(100).IsRequired();
            builder.Property(l => l.Content).HasMaxLength(250).IsRequired();
            builder.Property(l => l.PublishDate).HasDefaultValueSql("getdate()");
        }
    }
}