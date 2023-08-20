using Microsoft.AspNetCore.Mvc;

namespace EksiSozluk.PresentationLayer.ViewComponents.Default
{
    public class _SearchPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
