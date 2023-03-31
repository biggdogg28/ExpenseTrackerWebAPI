﻿using System.ComponentModel.DataAnnotations;

namespace ExpenseTrackerWebAPI.DTOs
{
    public class Totals
    {
        [Key]
        public Guid IdTotals { get; set; }
        public decimal TotalExpenses { get; set; }
        public decimal TotalIncome { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedOn { get; set; }
        public decimal Balance { get; set; }
    }
}