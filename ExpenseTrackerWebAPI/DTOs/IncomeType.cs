using System.ComponentModel.DataAnnotations;

namespace ExpenseTrackerWebAPI.DTOs
{
    public class IncomeType
    {
        [Key]
        public Guid IncomeTypeID { get; set; }
        public string? Name { get; set; }
    }
}
