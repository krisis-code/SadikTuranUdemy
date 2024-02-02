using Microsoft.AspNetCore.Identity;

namespace ProductsApi.Models
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; } = null!;

        public DateTime AddedTime { get; set; }
    }
}
