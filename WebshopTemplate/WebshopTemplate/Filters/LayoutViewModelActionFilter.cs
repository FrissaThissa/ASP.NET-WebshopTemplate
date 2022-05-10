using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebshopTemplate.Services;
using WebshopTemplate.ViewModels.Layout;

namespace WebshopTemplate.Filters
{
    public class LayoutViewModelActionFilter : IActionFilter
    {
        private readonly ICategoryService _categoryService;

        public LayoutViewModelActionFilter(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            return;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var controller = context.Controller as Controller;
            if (controller == null)
                return;
            controller.ViewData["LayoutViewModel"] = new LayoutViewModel_Default(_categoryService);
        }
    }
}
