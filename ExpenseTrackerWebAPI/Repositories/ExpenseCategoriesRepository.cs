using AutoMapper;
using ExpenseTrackerWebAPI.DataContext;

namespace ExpenseTrackerWebAPI.Repositories
{
    public class ExpenseCategoriesRepository : IExpenseCategoriesRepository
    {
        private readonly ExpenseTrackerDataContext _context;

        private readonly IMapper _mapper;

        public ExpenseCategoriesRepository(ExpenseTrackerDataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
    }
}
