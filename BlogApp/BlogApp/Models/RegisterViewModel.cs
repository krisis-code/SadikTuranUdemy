using BlogApp.Entity;
using System.ComponentModel.DataAnnotations;

namespace BlogApp.Models
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Kullanıcı Adı")]
        public string? UserName { get; set; }
        
        [Required]
        [Display(Name = "Ad Soyad")]
        public string? Name { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name ="Eposta")]
        public string? Email { get; set; }

        [Required]
        [StringLength(maximumLength:20 , MinimumLength = 6 , ErrorMessage = "Min 6 maks 20 karakter belirtiniz")]
        [DataType(DataType.Password)]
        [Display(Name = "Şifre")]
        public string? Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password) , ErrorMessage = "Parolanız eşleşmiyor")]
        [Display(Name = "Şifre Tekrar")]
        public string? ConfirmPassword { get; set; }



    }
}
