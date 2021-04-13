namespace entity
{
    public class CatCommentUserLike
    {
        public int CatCommentId { get; set; }
        public CatComment CatComment { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

    }
}