using System.ComponentModel.DataAnnotations;

namespace ExpenseTrackerWebAPI.Authentication
{
    public class AuthenticateRequest
    {
        [Required]
        public Guid Username { get; set; } //IdMember - tabela Member
        [Required]
        public string Password { get; set; } //name - tabela Member
    }
}
