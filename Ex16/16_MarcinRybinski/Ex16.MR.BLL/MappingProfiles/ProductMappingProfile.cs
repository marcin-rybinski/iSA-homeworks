using AutoMapper;
using Ex16.MR.BLL.Models;
using Ex16.MR.BLL.Models.DTO;

namespace Ex16.MR.BLL.MappingProfiles
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<Product, ShowProductDto>();
            CreateMap<CreateProductDto, Product>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<UpdateProductDto, Product>();
        }
    }
}
