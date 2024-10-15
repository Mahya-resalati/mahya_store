using mahya_store.Application.Services.Products.Commands.AddNewCategory;
using mahya_store.Application.Services.Products.Commands.AddNewProduct;
using mahya_store.Application.Services.Products.Queries.GetAllCategories;
using mahya_store.Application.Services.Products.Queries.GetCategories;
using mahya_store.Application.Services.Products.Queries.GetProductDetailForAdmin;
using mahya_store.Application.Services.Products.Queries.GetProductDetailForSite;
using mahya_store.Application.Services.Products.Queries.GetProductForAdmin;
using mahya_store.Application.Services.Products.Queries.GetProductForSite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mahya_store.Application.Interfaces.FacadPatterns
{
    public interface IProductFacad
    {
        AddNewCategoryService AddNewCategoryService { get; }
        IGetCategoriesService GetCategoriesService { get; }
        AddNewProductService AddNewProductService { get; }
        IGetAllCategoriesService GetAllCategoriesService { get; }

        IGetProductForAdminService GetProductForAdminService { get; }
        IGetProductDetailForAdminService GetProductDetailForAdminService { get; }

        IGetProductForSiteService GetProductForSiteService { get; }
        IGetProductDetailForSiteService GetProductDetailForSiteService { get; }
    }
}
