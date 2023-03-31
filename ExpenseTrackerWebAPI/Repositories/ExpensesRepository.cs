using AutoMapper;
using ExpenseTrackerWebAPI.DataContext;

namespace ExpenseTrackerWebAPI.Repositories
{
    public class ExpensesRepository : IExpensesRepository
    {
        private readonly ExpenseTrackerDataContext _context;

        private readonly IMapper _mapper;

        public ExpensesRepository(ExpenseTrackerDataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
    }
}