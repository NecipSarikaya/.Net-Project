namespace entity
{
    public class UniCommentUserLike
    {
        public int UniCommentId { get; set; }
        public UniComment UniComment { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

    }
}