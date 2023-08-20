using EksiSozluk.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace EksiSozluk.PresentationLayer.Controllers
{
    public class HeadingController : Controller
    {
        private readonly IHeadingService _headingService;

        public HeadingController(IHeadingService headingService)
        {
            _headingService = headingService;
        }

        public IActionResult Index()
        {
            var values = _headingService.TGetList();
            return View(values);
        }
    }
}
