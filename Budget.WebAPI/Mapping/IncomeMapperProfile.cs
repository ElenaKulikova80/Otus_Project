using AutoMapper;
using Budget.DAL.Entities;
using Budget.WebAPI.DTO.Income;

namespace Budget.WebAPI.Mappers
{
    public class IncomeMapperProfile : Profile
    {
        public IncomeMapperProfile() 
        {
            CreateMap<IncomeInputModel, Income>();
            CreateMap<Income, IncomeShowModel>();
            CreateMap<IncomeUpdateModel, Income>();
        }
    }
}
