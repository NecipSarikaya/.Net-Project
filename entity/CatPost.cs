using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace entity
{
    public class CatPost
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public bool IsReported { get; set; }
        public DateTime PublishDate { get; set; }
        public int LikeCount { get; set; }
        public bool IsVisible { get; set; }
        public List<CatComment> CatComments { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}