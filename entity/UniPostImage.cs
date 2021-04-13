using System.ComponentModel.DataAnnotations;

namespace entity
{
    public class UniPostImage
    {
        public int UniPostId { get; set; }
        public UniPost UniPosts { get; set; }
        public string ImageUrl { get; set; }
    }
}