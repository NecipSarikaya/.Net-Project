namespace entity
{
    public class CatPostUserLike
    {
        public int CatPostId { get; set; }
        public CatPost CatPost { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

    }
}