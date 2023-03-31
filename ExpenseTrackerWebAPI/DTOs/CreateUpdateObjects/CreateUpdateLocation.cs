using System.ComponentModel.DataAnnotations;

namespace ExpenseTrackerWebAPI.DTOs.CreateUpdateObjects
{
    public class CreateUpdateLocation
    {
        [Key]
        public Guid IdLocation { get; set; }
        public string? Name { get; set; }
    }
}
