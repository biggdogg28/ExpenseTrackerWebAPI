using AutoMapper;
using ExpenseTrackerWebAPI.DTOs;
using ExpenseTrackerWebAPI.DTOs.CreateUpdateObjects;

namespace ExpenseTrackerWebAPI
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Location, CreateUpdateLocation>().ReverseMap();
            CreateMap<Totals, CreateUpdateTotals>().ReverseMap();
            CreateMap<ExpenseCategory, CreateUpdateExpenseCategory>().ReverseMap();
            CreateMap<Expense, CreateUpdateExpense>().ReverseMap();
            CreateMap<IncomeType, CreateUpdateIncomeType>().ReverseMap();
            CreateMap<Income, CreateUpdateIncome>().ReverseMap();
        }
    }
}
