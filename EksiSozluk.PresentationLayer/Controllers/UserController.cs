using EksiSozluk.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EksiSozluk.PresentationLayer.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IContentService _contentService;

        public UserController(IUserService userService, IContentService contentService)
        {
            _userService = userService;
            _contentService = contentService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult UserDetail(int id)
        {
            var values = _userService.TGetById(id);
            return View(values);


        }

        [HttpGet]
        public IActionResult UserWriter(int id)
        {
            var values = _contentService.GetListByWriter(id);
            var jsoncontent = JsonConvert.SerializeObject(values);
            return Json(jsoncontent);
        }
    }
}
