using EksiSozluk.EntityLayer.Concrete;
using EksiSozluk.PresentationLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EksiSozluk.PresentationLayer.Controllers
{
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        public LoginController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel model)
        {

            var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, true, true);
          

            if (result.Succeeded)
            {
                //return RedirectToAction("Index", "Default");
                return RedirectToAction("ContentByHeading" ,"Content");
            }
            return View();
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Default");
        }

    }
}
