using System.ComponentModel.DataAnnotations;

namespace ExpenseTrackerWebAPI.DTOs.PatchObjects
{
    public class PatchIncomeType
    {
        [Key]
        public Guid IncomeTypeID { get; set; }
        public string? Name { get; set; }
    }
}
