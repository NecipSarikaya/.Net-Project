using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace entity
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameUrl { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public List<CatPost> CatPosts { get; set; }
    }
}