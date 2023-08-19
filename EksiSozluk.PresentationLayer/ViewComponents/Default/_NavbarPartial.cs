using Microsoft.AspNetCore.Mvc;

namespace EksiSozluk.PresentationLayer.ViewComponents.Default
{
    public class _NavbarPartial :  ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
