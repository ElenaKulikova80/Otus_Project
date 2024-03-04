using AutoMapper;
using Budget.WebAPI.DTO;
using Budget.DAL.Entities;

namespace Budget.WebAPI.Mapping
{
    public class ExpenseMappingProfile:Profile
    {
        public ExpenseMappingProfile()
        {
            CreateMap<Expense, ExpenseInputModel>();
            CreateMap<Expense, ExpenseShowModel>();
            CreateMap<ExpenseShowModel, Expense>();
            CreateMap<ExpenseInputModel, Expense>();
        }
    }
}
