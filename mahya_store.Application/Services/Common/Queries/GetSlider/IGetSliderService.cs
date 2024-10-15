using mahya_store.Application.Interfaces.Contexts;
using mahya_store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mahya_store.Application.Services.Common.Queries.GetSlider
{
    public interface IGetSliderService
    {
        ResultDto<List<SlidersDto>> Execute();
    }

    public class GetSLiderService : IGetSliderService
    {
        private readonly IDataBaseContext _context;
        public GetSLiderService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<List<SlidersDto>> Execute()
        {
            var slider = _context.Sliders.OrderByDescending(p => p.Id).ToList()
                .Select(p => new SlidersDto
                {
                    Link = p.Link,
                    Src = p.Src,
                }).ToList();

            return new ResultDto<List<SlidersDto>>()
            {
                Data = slider,
                IsSuccess = true,
            };

        }
    }

    public class SlidersDto
    {
        public string Src { get; set; }
        public string Link { get; set; }
    }
}
