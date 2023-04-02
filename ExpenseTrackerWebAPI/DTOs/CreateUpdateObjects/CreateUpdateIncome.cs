using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ExpenseTrackerWebAPI.DTOs.CreateUpdateObjects
{
    public class CreateUpdateIncome
    {
        [Key]
        [JsonIgnore]
        public Guid IdIncome { get; set; }
        public string? Name { get; set; }
        public decimal Amount { get; set; }
        public Guid IncomeTypeID { get; set; }
        public string? Notes { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
