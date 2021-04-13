using entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace data.Configuration
{
    public class CatCommentConfiguration : IEntityTypeConfiguration<CatComment>
    {
        public void Configure(EntityTypeBuilder<CatComment> builder)
        {
            builder.HasKey(l => l.Id);
            builder.Property(m => m.CommentContent).IsRequired().HasMaxLength(200);
            builder.Property(m => m.CommentDate).HasDefaultValueSql("getdate()");

        }
    }
}