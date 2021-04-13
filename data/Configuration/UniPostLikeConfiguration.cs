using entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace data.Configuration
{
    public class UniPostUserLikeConfiguration : IEntityTypeConfiguration<UniPostUserLike>
    {
        public void Configure(EntityTypeBuilder<UniPostUserLike> builder)
        {
            builder.HasKey(l => new { l.UserId,l.UniPostId});
        }
    }
}