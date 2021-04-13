namespace entity
{
    public class UniPostUserLike
    {
        public UniPost UniPost { get; set; }
        public int UniPostId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    
    }
}