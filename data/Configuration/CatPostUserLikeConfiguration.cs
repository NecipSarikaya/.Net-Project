using entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace data.Configuration
{
    public class CatPostUserLikeConfiguration : IEntityTypeConfiguration<CatPostUserLike>
    {
        public void Configure(EntityTypeBuilder<CatPostUserLike> builder)
        {
            builder.HasKey(l => new{l.CatPostId,l.UserId});
        }
    }
}