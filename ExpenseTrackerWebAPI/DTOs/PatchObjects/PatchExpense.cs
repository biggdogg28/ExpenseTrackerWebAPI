﻿using System.ComponentModel.DataAnnotations;

namespace ExpenseTrackerWebAPI.DTOs.PatchObjects
{
    public class PatchExpense
    {
        [Key]
        public Guid IdExpense { get; set; }
        public Guid ExpenseCategoryID { get; set; }
        public int Amount { get; set; }
        public Guid IdLocation { get; set; }
        public string? Notes { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}