using data.Configuration;
using entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace data.Concrete
{
    public class MentorContext : IdentityDbContext<User,Role,int>
    {
        public MentorContext(DbContextOptions<MentorContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CatComment> CatComments { get; set; }
        public DbSet<CatPost> CatPosts { get; set; }
        public DbSet<UniPost> UniPosts { get; set; }
        public DbSet<UniComment> UniComments { get; set; }
        public DbSet<University> Universities { get; set; }        
        public DbSet<Department> Departments { get; set; }
        public DbSet<UserFollowUser> UserFollowUser { get; set; }
        public DbSet<UniPostImage> UniPostImages { get; set; }
        public DbSet<CatPostImage> CatPostImages { get; set; }
        public DbSet<UniversityDepartment> UniversityDepartments { get; set; }
        public DbSet<UniPostUserLike> UniPostUserLikes { get; set; }
        public DbSet<UniCommentUserLike> UniCommentUserLikes { get; set; }
        public DbSet<CatPostUserLike> CatPostUserLikes { get; set; }
        public DbSet<CatCommentUserLike> CatCommentUserLikes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.ApplyConfiguration(new CatCommentConfiguration());
            modelBuilder.ApplyConfiguration(new CatCommentUserLikeConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new CatPostConfiguration());
            modelBuilder.ApplyConfiguration(new CatPostImageConfiguration());
            modelBuilder.ApplyConfiguration(new CatPostUserLikeConfiguration());
            modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
            modelBuilder.ApplyConfiguration(new UniCommentConfiguration());
            modelBuilder.ApplyConfiguration(new UniCommentUserLikeConfiguration());
            modelBuilder.ApplyConfiguration(new UniPostConfiguration());
            modelBuilder.ApplyConfiguration(new UniPostImageConfiguration());
            modelBuilder.ApplyConfiguration(new UniPostUserLikeConfiguration());
            modelBuilder.ApplyConfiguration(new UniversityConfiguration());
            modelBuilder.ApplyConfiguration(new UniversityDepartmentConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserFollowUserConfiguration());
        
            modelBuilder.Entity<UserFollowUser>().HasOne(l => l.User)
                .WithMany(a => a.Followers)
                .HasForeignKey( l => l.FollowerId);
            modelBuilder.Entity<UserFollowUser>().HasOne(l => l.Follower)
                .WithMany(a => a.Followings)
                .HasForeignKey( l => l.UserId);
        }
    }
}