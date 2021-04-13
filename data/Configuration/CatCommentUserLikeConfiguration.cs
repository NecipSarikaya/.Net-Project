using entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace data.Configuration
{
    public class CatCommentUserLikeConfiguration: IEntityTypeConfiguration<CatCommentUserLike>
    {
        public void Configure(EntityTypeBuilder<CatCommentUserLike> builder)
        {
            builder.HasKey(l => new {l.UserId,l.CatCommentId});
        }
    }
}