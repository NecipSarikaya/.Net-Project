using System;
using System.ComponentModel.DataAnnotations;

namespace entity
{
    public class UniComment
    {
        public int Id { get; set; }
        public string CommentContent { get; set; }
        public DateTime CommentDate { get; set; }
        public int LikeCount { get; set; }
        public bool IsReported { get; set; }
        public bool IsVisible { get; set; }
        public bool IsFavorite { get; set; }
        public int UniPostId { get; set; }
        public UniPost UniPost { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}