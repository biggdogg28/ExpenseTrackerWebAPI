using System.ComponentModel.DataAnnotations;

namespace ExpenseTrackerWebAPI.DTOs
{
    public class Users
    {
        [Key]
        public Guid IdUser { get; set; }
        public string? Username { get; set; }
    }
}
