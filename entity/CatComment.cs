using System;
using System.ComponentModel.DataAnnotations;

namespace entity
{
    public class CatComment
    {
        public int Id { get; set; }
        public string CommentContent { get; set; }
        public DateTime CommentDate { get; set; }
        public int LikeCount { get; set; }
        public bool IsVisible { get; set; }
        public bool IsFavorite { get; set; }
        public bool IsReported { get; set; }
        public int CatPostId { get; set; }
        public CatPost CatPost { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}