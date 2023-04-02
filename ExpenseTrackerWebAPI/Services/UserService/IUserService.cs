using ExpenseTrackerWebAPI.Authentication;

namespace ExpenseTrackerWebAPI.Services.UserService
{
    public interface IUserService
    {
        AuthenticationResponse Authenticate(AuthenticateRequest model);
    }
}
