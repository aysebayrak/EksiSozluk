using EksiSozluk.EntityLayer.Concrete;
using EksiSozluk.PresentationLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MailKit.Net.Smtp;


namespace EksiSozluk.PresentationLayer.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new RegisterViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Index(RegisterViewModel model)
        {
            Random rnd = new Random();
            int x = rnd.Next(100000, 1000000);

            AppUser appUser = new AppUser
            {
               
                Email = model.Email,
                UserName = model.UserName,
                ConfirmCode = x
            };

            if (ModelState.IsValid)
            {
                if (model.ConfirmPassword == model.PasswordHash)
                {

                    MimeMessage mimeMessage = new MimeMessage();
                    MailboxAddress mailboxAddress = new MailboxAddress("Admin", "ayse.bayrak812@gmail.com");
                    mimeMessage.From.Add(mailboxAddress);

                    MailboxAddress mailboxAddressTo = new MailboxAddress("User", model.Email);
                    mimeMessage.To.Add(mailboxAddressTo);

                    var bodyBuilder = new BodyBuilder();
                    bodyBuilder.TextBody = "Giriş yapabilmek için onaylama kodunuz: " + x;
                    mimeMessage.Body = bodyBuilder.ToMessageBody();

                    mimeMessage.Subject = "Doğrulama kodu";

                    SmtpClient smtpClient = new SmtpClient();
                    smtpClient.Connect("smtp.gmail.com", 587, false);
                    smtpClient.Authenticate("ayse.bayrak812@gmail.com", "npzszpmfhwvcywcp");
                    smtpClient.Send(mimeMessage);
                    smtpClient.Disconnect(true);


                    var result = await _userManager.CreateAsync(appUser, model.PasswordHash);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "ConfirmedMail", new { id = appUser.Id });
                    }
                    else
                    {
                        foreach (var item in result.Errors)
                        {
                            ModelState.AddModelError("", item.Description);
                        }
                    }

                }
                else
                {
                    ModelState.AddModelError("", "Şifreler Eşleşmiyor");
                }
            }

            return View();
        }
    }
}
