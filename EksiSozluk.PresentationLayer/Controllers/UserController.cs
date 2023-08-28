using EksiSozluk.BusinessLayer.Abstract;
using EksiSozluk.DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace EksiSozluk.PresentationLayer.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IContentService _contentService;
        private readonly EksiSozlukContext _context;

        public UserController(IUserService userService, IContentService contentService, EksiSozlukContext context)
        {
            _userService = userService;
            _contentService = contentService;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult UserDetail(int id)
        {
           
            var userContentCounts = CalculateUserContentCounts();
            ViewBag.UserContentCounts = userContentCounts;
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


        private Dictionary<string, int> CalculateUserContentCounts()
        {
            var userContentCounts = new Dictionary<string, int>();

            var users = _context.Users.Include(u => u.Contents).ToList();
            foreach (var user in users)
            {
                userContentCounts[user.UserName] = user.Contents.Count;
            }

            return userContentCounts;
        }

    }
}
