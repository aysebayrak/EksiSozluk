using EksiSozluk.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace EksiSozluk.PresentationLayer.Controllers
{
    public class ContentController : Controller
    {
        private readonly IContentService _contentService;

        public ContentController(IContentService contentService)
        {
            _contentService = contentService;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
