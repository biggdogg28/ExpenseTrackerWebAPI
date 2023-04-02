using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ExpenseTrackerWebAPI.DTOs.CreateUpdateObjects
{
    public class CreateUpdateExpenseCategory
    {
        [Key]
        [JsonIgnore]
        public Guid ExpenseCategoryID { get; set; }
        public string? Name { get; set; }
    }
}
