namespace BlogApp.Entity
{
    public class Comment
    {
        public int CommentId { get; set; }

        public string? Text { get; set; }

        public DateTime PublishedOn { get; set; }

        public string  PotsId { get; set; }

        public Post Pots { get; set; } = null!;

        public string UserId { get; set; }

        public User User { get; set; } = null!;


    }
}
