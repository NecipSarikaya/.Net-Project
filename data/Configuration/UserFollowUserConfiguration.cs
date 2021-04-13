using entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace data.Configuration
{
    public class UserFollowUserConfiguration : IEntityTypeConfiguration<UserFollowUser>
    {
        public void Configure(EntityTypeBuilder<UserFollowUser> builder)
        {
            builder.HasKey(l => new{l.UserId,l.FollowerId});
        }
    }
}