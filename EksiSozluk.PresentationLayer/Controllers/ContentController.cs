using EksiSozluk.BusinessLayer.Abstract;
using EksiSozluk.DataAccessLayer.Concrete;
using EksiSozluk.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EksiSozluk.PresentationLayer.Controllers
{
    public class ContentController : Controller
    {
        private readonly IContentService _contentService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<AppUser> _userManager;

        public ContentController(IContentService contentService, IHttpContextAccessor httpContextAccessor, UserManager<AppUser> userManager)
        {
            _contentService = contentService;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var values = _contentService.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddContent(int id)
        {

            return View();
        }



        [HttpPost]
        public async Task<IActionResult> AddContent([FromBody] Content content)
        {
            EksiSozlukContext context = new EksiSozlukContext();

            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (user == null)
            {
                return BadRequest("Kullanıcı bulunamadı");
            }

            //int headingId = Convert.ToInt32(HttpContext.Session.GetInt32("HeadingId"));
            var headingId = content.HeadingId;
            content.ContentDate = DateTime.Now;


            //content.AppUser = new AppUser { Id = user.Id };
            content.AppUser = user;
            content.ContentStatus = true;
            content.HeadingId = headingId;

            context.Contents.Add(content);
            context.SaveChanges();

            return NoContent();
        }



        public IActionResult DeleteContent(int id)
        {
            var value = _contentService.TGetById(id);
            _contentService.TDelete(value);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateContent(int id)
        {
            var value = _contentService.TGetById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateContent(Content content)
        {
            _contentService.TUpdate(content);
            return RedirectToAction("Index");

        }

        public IActionResult ContentByHeading(int id = 1)
        {

            var values = _contentService.GetListByHeadingID(id);
            return View(values);
        }
        public IActionResult ContentByHeadingWriter(int id = 0)
        {
            var values = _contentService.GetListByHeadingID(id);
            return View(values);
        }
    }
}
