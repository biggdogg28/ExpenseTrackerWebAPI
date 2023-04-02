using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ExpenseTrackerWebAPI.DTOs.PatchObjects
{
    public class PatchExpense
    {
        [Key]
        [JsonIgnore]
        public Guid IdExpense { get; set; }
        public Guid ExpenseCategoryID { get; set; }
        public decimal Amount { get; set; }
        public Guid IdLocation { get; set; }
        public string? Notes { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
