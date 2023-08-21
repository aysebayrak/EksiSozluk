using EksiSozluk.BusinessLayer.Abstract;
using EksiSozluk.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace EksiSozluk.PresentationLayer.Controllers
{
    public class HeadingController : Controller
    {
        private readonly IHeadingService _headingService;
        private readonly IContentService _contentService;

        public HeadingController(IHeadingService headingService, IContentService contentService)
        {
            _headingService = headingService;
            _contentService = contentService;
        }

        public IActionResult Index()
        {
            var values = _headingService.TGetList();
            return View(values);
        }

     
    }
}
