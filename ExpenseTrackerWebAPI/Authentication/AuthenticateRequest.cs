using System.ComponentModel.DataAnnotations;

namespace ExpenseTrackerWebAPI.Authentication
{
    public class AuthenticateRequest
    {
        [Required]
        public Guid Username { get; set; } //IdUser - tabela Users
        [Required]
        public string Password { get; set; } //Username - tabela Users
    }
}
