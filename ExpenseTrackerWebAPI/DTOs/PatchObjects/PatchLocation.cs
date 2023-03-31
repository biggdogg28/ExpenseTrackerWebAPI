using System.ComponentModel.DataAnnotations;

namespace ExpenseTrackerWebAPI.DTOs.PatchObjects
{
    public class PatchLocation
    {
        [Key]
        public Guid IdLocation { get; set; }
        public string? Name { get; set; }
    }
}
