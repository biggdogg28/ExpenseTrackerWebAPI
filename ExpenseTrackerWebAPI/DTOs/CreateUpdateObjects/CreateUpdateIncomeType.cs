using System.ComponentModel.DataAnnotations;

namespace ExpenseTrackerWebAPI.DTOs.CreateUpdateObjects
{
    public class CreateUpdateIncomeType
    {
        [Key]
        public Guid IncomeTypeID { get; set; }
        public string? Name { get; set; }
    }
}
