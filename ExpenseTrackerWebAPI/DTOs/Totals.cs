using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseTrackerWebAPI.DTOs
{
    public class Totals
    {
        [Key]
        public Guid IdTotals { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalExpenses { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalIncome { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedOn { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Balance { get; set; }
    }
}
