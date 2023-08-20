using EksiSozluk.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace EksiSozluk.PresentationLayer.Controllers
{
    public class CategoryController : Controller
    {
        private ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var values = _categoryService.TGetList();
            return View(values);
        }
        public IActionResult HeadingsByCategory(int categoryId)
        {
            return ViewComponent("_SidebarPartial", new { categoryId });
        }
    }
}
