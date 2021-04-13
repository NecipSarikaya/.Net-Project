using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace entity
{
    public class User: IdentityUser<int>
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string ImageUrl { get; set; }
        public int UniversityId { get; set; }
        public int Point { get; set; }
        public string About { get; set; }
        public string InstagramLink { get; set; }
        public string TwitterLink { get; set; }
        public University University { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public List<UniPost> UniPosts { get; set; }
        public List<CatPost> CatPosts { get; set; }
        public List<UniComment> UniComments { get; set; }
        public List<CatComment> CatComments { get; set; }
        public List<UserFollowUser> Followings { get; set; }
        public List<UserFollowUser> Followers { get; set; }
    }
}