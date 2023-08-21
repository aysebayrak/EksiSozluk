using System.ComponentModel.DataAnnotations;

namespace EksiSozluk.PresentationLayer.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Kullanıcı mail giriniz...")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifreyi giriniz...")]
        public string PasswordHash { get; set; }
    }
}
