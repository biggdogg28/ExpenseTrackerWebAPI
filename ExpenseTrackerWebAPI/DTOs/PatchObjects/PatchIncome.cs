using System.ComponentModel.DataAnnotations;

namespace ExpenseTrackerWebAPI.DTOs.PatchObjects
{
    public class PatchIncome
    {
        [Key]
        public Guid IdIncome { get; set; }
        public string? Name { get; set; }
        public decimal Amount { get; set; }
        public Guid IncomeTypeID { get; set; }
        public string? Notes { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
