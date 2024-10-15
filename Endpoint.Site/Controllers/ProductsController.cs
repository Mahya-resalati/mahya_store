using mahya_store.Application.Interfaces.FacadPatterns;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using static mahya_store.Application.Services.Products.Queries.GetProductForSite.IGetProductForSiteService;

namespace Endpoint.Site.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductFacad _productFacad;
        public ProductsController(IProductFacad productFacad)
        {
            _productFacad = productFacad;
        }
        public IActionResult Index(Ordering ordering, string SearchKey, long? CatId = null, int page=1, int PageSize=20)
        {
            return View(_productFacad.GetProductForSiteService.Execute(ordering, SearchKey, CatId, page, PageSize).Data);
        }

        public IActionResult Detail(int Id)
        {
            return View(_productFacad.GetProductDetailForSiteService.Execute(Id).Data);
        }
    }
}
