using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ExpenseTrackerWebAPI.DTOs.PatchObjects
{
    public class PatchExpenseCategory
    {
        [Key]
        [JsonIgnore]
        public Guid ExpenseCategoryID { get; set; }
        public string? Name { get; set; }
    }
}
