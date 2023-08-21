using System.ComponentModel.DataAnnotations;

namespace EksiSozluk.PresentationLayer.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Kullanıcı Adı boş geçilemez!")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Şifre alanı boş geçilemez!")]
        public string PasswordHash { get; set; }

        [Required(ErrorMessage = "Email alanı boş geçilemez!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Lütfen Şifreyi Tekrar Girin")]
        [Compare("PasswordHash", ErrorMessage = "Şifreler Uyumlu Değil")]
        public string ConfirmPassword { get; set; }
    }
}
