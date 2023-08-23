using System.ComponentModel.DataAnnotations;

namespace EksiSozluk.PresentationLayer.Models
{
    public class LoginViewModel
    {
        //[Required(ErrorMessage = "Kullanıcı mail giriniz...")]
        //public string Email { get; set; }

        [Required(ErrorMessage = "Şifreyi giriniz...")]
        public string Password { get; set; }

        [Display(Name = "Kullanıcı Adı")]
        [Required(ErrorMessage = "Kullanıcı Adını giriniz...")]
        public string Username { get; set; }
    }
}
