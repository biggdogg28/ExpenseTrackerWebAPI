using ExpenseTrackerWebAPI.DTOs;

namespace ExpenseTrackerWebAPI.Repositories
{
    public interface IUsersRepository
    {
        public Task<IEnumerable<Users>> GetUsersAsync();
    }
}
