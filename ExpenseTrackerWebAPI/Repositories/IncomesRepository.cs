using AutoMapper;
using ExpenseTrackerWebAPI.DataContext;
using ExpenseTrackerWebAPI.DTOs;
using ExpenseTrackerWebAPI.DTOs.CreateUpdateObjects;
using ExpenseTrackerWebAPI.DTOs.PatchObjects;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTrackerWebAPI.Repositories
{
    public class IncomesRepository : IIncomesRepository
    {
        private readonly ExpenseTrackerDataContext _context;

        private readonly IMapper _mapper;

        public IncomesRepository(ExpenseTrackerDataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
    }
}
