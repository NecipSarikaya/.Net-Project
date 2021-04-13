using entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace data.Configuration
{
    public class UniCommentUserLikeConfiguration : IEntityTypeConfiguration<UniCommentUserLike>
    {
        public void Configure(EntityTypeBuilder<UniCommentUserLike> builder)
        {
            builder.HasKey(l => new { l.UserId,l.UniCommentId});
        }
    }
}