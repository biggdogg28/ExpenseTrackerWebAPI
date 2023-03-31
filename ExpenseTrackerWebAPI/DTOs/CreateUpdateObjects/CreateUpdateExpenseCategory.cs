using System.ComponentModel.DataAnnotations;

namespace ExpenseTrackerWebAPI.DTOs.CreateUpdateObjects
{
    public class CreateUpdateExpenseCategory
    {
        [Key]
        public Guid ExpenseCategoryID { get; set; }
        public string? Name { get; set; }
    }
}
