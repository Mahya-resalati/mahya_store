using mahya_store.Application.Services.HomePage.AddHomepageImages;
using mahya_store.Domain.Entities.HomePage;
using Microsoft.AspNetCore.Mvc;

namespace Endpoint.Site.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomePageImagesController : Controller
    {
        private readonly IAddHomePageImagesService _addHomePageImagesService;
        public HomePageImagesController(IAddHomePageImagesService addHomePageImagesService)
        {
            _addHomePageImagesService = addHomePageImagesService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(IFormFile File, string Link, ImageLocation ImageLocation)
        {
            _addHomePageImagesService.Execute(new RequestAddHomePageImagesDto
            {
                File = File,
                Link = Link,
                ImageLocation = ImageLocation,
            });
            return View();
        }
    }
}
