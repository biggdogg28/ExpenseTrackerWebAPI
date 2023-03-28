using System.ComponentModel.DataAnnotations;

namespace ExpenseTrackerWebAPI.DTOs
{
    public class Location
    {
        [Key]
        public Guid IdLocation { get; set; }
        public string? Name { get; set; }
    }
}
