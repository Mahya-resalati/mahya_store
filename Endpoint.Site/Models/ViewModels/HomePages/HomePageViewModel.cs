using mahya_store.Application.Services.Common.Queries.GetHomePageImage;
using mahya_store.Application.Services.Common.Queries.GetSlider;
using mahya_store.Application.Services.Products.Queries.GetProductForSite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Endpoint.Site.Models.ViewModels.HomePages
{
    public class HomePageViewModel
    {
        public List<SlidersDto> Sliders { get; set; }
        public List<HomePageImagesDto> PageImages { get; set; }
        public List<ProductForSiteDto> Camera { get; set; }
        public List<ProductForSiteDto> Mobile { get; set; }
        public List<ProductForSiteDto> Laptop { get; set; }
        public List<ProductForSiteDto> Furniture { get; set; }


    }
}
