using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ExpenseTrackerWebAPI.DTOs.PatchObjects
{
    public class PatchTotals
    {
        [Key]
        [JsonIgnore]
        public Guid IdTotals { get; set; }
        public decimal TotalExpenses { get; set; }
        public decimal TotalIncome { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedOn { get; set; }
        public decimal Balance { get; set; }
    }
}
