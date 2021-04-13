using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace entity
{
    public class University
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameUrl { get; set; }
        public List<UniPost> UniPosts { get; set; }
    }
}