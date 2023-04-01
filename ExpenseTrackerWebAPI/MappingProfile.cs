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
        }
    }
}
