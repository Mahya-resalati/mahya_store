using Endpoint.Site.Models;
using Endpoint.Site.Models.ViewModels.HomePages;
using mahya_store.Application.Interfaces.FacadPatterns;
using mahya_store.Application.Services.Common.Queries.GetHomePageImage;
using mahya_store.Application.Services.Common.Queries.GetSlider;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using static mahya_store.Application.Services.Products.Queries.GetProductForSite.IGetProductForSiteService;

namespace Endpoint.Site.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IGetSliderService _getSliderService;
        private readonly IGetHomePageImageService _getHomePageImageService;
        private readonly IProductFacad _productFacad;

        public HomeController(ILogger<HomeController> logger,
            IGetSliderService getSliderService,
            IGetHomePageImageService getHomePageImageService,
            IProductFacad productFacad)
        {
            _logger = logger;
            _getSliderService = getSliderService;
            _getHomePageImageService = getHomePageImageService;
            _productFacad = productFacad;
        }

        public IActionResult Index()
        {
            HomePageViewModel homePage = new HomePageViewModel()
            {
                Sliders = _getSliderService.Execute().Data,
                PageImages = _getHomePageImageService.Execute().Data,
                Laptop = _productFacad.GetProductForSiteService.Execute(Ordering.TheNewest, null, 10008, 1, 6).Data.Products,
                Mobile = _productFacad.GetProductForSiteService.Execute(Ordering.TheNewest, null, 10009, 1, 6).Data.Products,
                Furniture = _productFacad.GetProductForSiteService.Execute(Ordering.TheNewest, null, 10010, 1, 6).Data.Products,
                Camera = _productFacad.GetProductForSiteService.Execute(Ordering.TheNewest, null, 10011, 1, 6).Data.Products,
            };
            return View(homePage);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
