using System.ComponentModel.DataAnnotations;

namespace MeetingApp.Models
{
    public class UserInfo
    {
        public int Id {get; set;}
    [Required]
    public String? Name { get; set; }
    [Required]
    public String? Phone { get; set; }
    [Required]
    [EmailAddress]
    public String? Email { get; set; }
    [Required]
    public bool? WillAttend { get; set; }
   
    }


}