using ExpenseTrackerWebAPI.DTOs;

namespace ExpenseTrackerWebAPI.Services
{
    public interface IUsersService
    {
        public Task<IEnumerable<Users>> GetUsersAsync();
    }
}
