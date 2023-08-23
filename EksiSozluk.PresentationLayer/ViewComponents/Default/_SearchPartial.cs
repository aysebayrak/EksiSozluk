using EksiSozluk.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace EksiSozluk.PresentationLayer.ViewComponents.Default
{
    public class _SearchPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var userName = User.Identity.Name;
            ViewBag.name = userName;
            return View();
        }
    }
}
