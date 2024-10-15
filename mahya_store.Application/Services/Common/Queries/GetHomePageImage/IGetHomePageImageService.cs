using mahya_store.Application.Interfaces.Contexts;
using mahya_store.Common.Dto;
using mahya_store.Domain.Entities.HomePage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mahya_store.Application.Services.Common.Queries.GetHomePageImage
{
    public interface IGetHomePageImageService
    {
        ResultDto<List<HomePageImagesDto>> Execute();
    }

    public class GetHomePageImagesService : IGetHomePageImageService
    {
        private readonly IDataBaseContext _context;
        public GetHomePageImagesService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<List<HomePageImagesDto>> Execute()
        {
            var HomePageImages = _context.HomePageImages.OrderByDescending(p => p.Id)
                .Select(p => new HomePageImagesDto()
                {
                    Id = p.Id,
                    Src = p.Src,
                    Link = p.Link,
                    ImageLocation = p.ImageLocation,
                }).ToList();

            return new ResultDto<List<HomePageImagesDto>>()
            {
                Data = HomePageImages,
                IsSuccess = true
            };
        }
    }

    public class HomePageImagesDto()
    {
        public long Id { get; set; }
        public string Src { get; set; }
        public string Link { get; set; }
        public ImageLocation ImageLocation { get; set; }
    }
}
