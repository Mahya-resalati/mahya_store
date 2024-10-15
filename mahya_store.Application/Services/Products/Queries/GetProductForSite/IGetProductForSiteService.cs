using mahya_store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mahya_store.Application.Services.Products.Queries.GetProductForSite
{
    public interface IGetProductForSiteService
    {
        ResultDto<ResultProductForSiteDto> Execute(Ordering ordering, string SearchKey, long? CatId, int Page, int PageSize);

        public enum Ordering
        {
            NotOrder = 0,
            MostVisited = 1,
            BestSelling = 2,
            MostPopular = 3,
            TheNewest = 4,
            Cheapest = 5,
            TheMostExpensive = 6,
        }
    }
}
