using AutoMapper;
using Budget.DAL.Entities;
using Budget.WebAPI.DTO.Category;

namespace Budget.WebAPI.Mappers
{
    public class CategoryMapperProfile : Profile
    {
        public CategoryMapperProfile() 
        {
            CreateMap<CategoryInputModel, Category>();
            CreateMap<Category, CategoryShowModel>();
        }
    }
}
