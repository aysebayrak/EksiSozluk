using EksiSozluk.BusinessLayer.Abstract;
using EksiSozluk.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace EksiSozluk.PresentationLayer.ViewComponents.Default
{
    public class _NavbarPartial :  ViewComponent

    { 
        private readonly ICategoryService _categoryService;

        public _NavbarPartial(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IViewComponentResult Invoke()
        {
            var categories = _categoryService.GetActiveCategories();
            return View(categories);

        }
    }
}
