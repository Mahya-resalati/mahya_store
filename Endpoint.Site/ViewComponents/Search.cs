using mahya_store.Application.Services.Common.Queries.GetCategory;
using Microsoft.AspNetCore.Mvc;

namespace Endpoint.Site.ViewComponents
{
    public class Search:ViewComponent
    {
        private readonly IGetCategoryService _getCategoryService;
        public Search(IGetCategoryService getCategoryService)
        {
            _getCategoryService = getCategoryService;
        }

        public IViewComponentResult Invoke()
        {
            return View(viewName:"Search", _getCategoryService.Execute().Data);
        }
    }
}
