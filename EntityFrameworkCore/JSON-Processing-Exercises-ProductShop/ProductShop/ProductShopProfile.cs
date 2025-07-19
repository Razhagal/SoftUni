using AutoMapper;

using ProductShop.Models;
using ProductShop.DTOs.Import;
using ProductShop.DTOs.Export;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile() 
        {
            CreateMap<User, ImportUserDto>().ReverseMap();
            CreateMap<Product, ImportProductDto>().ReverseMap();
            CreateMap<Category, ImportCategoryDto>().ReverseMap();
            CreateMap<CategoryProduct, ImportCategoryProductDto>().ReverseMap();

            CreateMap<Product, ExportProductsInRangeDto>()
                .ForMember(dto => dto.Seller,
                    opt => opt.MapFrom(src => $"{src.Seller.FirstName} {src.Seller.LastName}"));

            CreateMap<Product, ExportProductSoldWithBuyerNamesDto>();
            CreateMap<User, ExportUsersWithSoldProductsDto>()
                .ForMember(dest => dest.SoldProducts,
                    opt => opt.MapFrom(src => src.ProductsSold.Where(p => p.BuyerId.HasValue)));

            CreateMap<Category, ExportCategoriesByProductsCountDto>()
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.ProductsCount, opt => opt.MapFrom(src => src.CategoriesProducts.Count))
                .ForMember(dest => dest.AveragePrice, opt => opt.MapFrom(src => (src.CategoriesProducts.Sum(p => p.Product.Price) / src.CategoriesProducts.Count).ToString("F2")))
                .ForMember(dest => dest.TotalRevenue, opt => opt.MapFrom(src => src.CategoriesProducts.Sum(p => p.Product.Price).ToString("F2")));

            CreateMap<Product, ExportProductNamePriceDto>();
            CreateMap<User, ExportUsersSoldProductsWithCountDto>()
                .ForMember(dest => dest.Count, opt => opt.MapFrom(src => src.ProductsSold.Count(p => p.BuyerId.HasValue)))
                .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.ProductsSold.Where(p => p.BuyerId.HasValue)));
            CreateMap<User, ExportUsersDataWithProductsSoldDto>()
                .ForMember(dest => dest.SoldProducts, opt => opt.MapFrom(src => src));

        }
    }
}
