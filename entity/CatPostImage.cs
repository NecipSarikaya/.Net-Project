using System.ComponentModel.DataAnnotations;

namespace entity
{
    public class CatPostImage
    {
        public int CatPostId { get; set; }
        public CatPost CatPost { get; set; }
        public string ImageUrl { get; set; }
    }
}