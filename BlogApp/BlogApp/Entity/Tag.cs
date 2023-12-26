using Microsoft.AspNetCore.Identity;

namespace BlogApp.Entity
{
    public class Tag
    {
        public int TagId { get; set; }

        public String? Text { get; set; }

        public List<Post> Pots { get; set; } = new List<Post>();
    }
}
