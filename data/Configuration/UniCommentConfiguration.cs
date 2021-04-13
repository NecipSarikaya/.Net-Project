using entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace data.Configuration
{
    public class UniCommentConfiguration : IEntityTypeConfiguration<UniComment>
    {
        public void Configure(EntityTypeBuilder<UniComment> builder)
        {
            builder.HasKey(l => l.Id);
            builder.Property(l => l.CommentContent).HasMaxLength(200).IsRequired();
            builder.Property(l => l.CommentDate).HasDefaultValueSql("getdate()");
        }
    }
}