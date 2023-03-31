using System.ComponentModel.DataAnnotations;

namespace ExpenseTrackerWebAPI.DTOs.PatchObjects
{
    public class PatchExpenseCategory
    {
        [Key]
        public Guid ExpenseCategoryID { get; set; }
        public string? Name { get; set; }
    }
}
