using System.ComponentModel.DataAnnotations;

namespace ExpenseTrackerWebAPI.DTOs
{
    public class ExpenseCategory
    {
        [Key]
        public Guid ExpenseCategoryID { get; set; }
        public string? Name { get; set; }
    }
}
