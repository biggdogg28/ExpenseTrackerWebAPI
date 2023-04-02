using ExpenseTrackerWebAPI.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ExpenseTrackerWebAPI.DataContext
{
    public class ExpenseTrackerDataContext : DbContext
    {
        public ExpenseTrackerDataContext(DbContextOptions<ExpenseTrackerDataContext> options) : base(options) { }

        public DbSet<ExpenseCategory> ExpenseCategory { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Income> Income { get; set; }
        public DbSet<IncomeType> IncomeType { get; set; }
        public DbSet<Location> Location { get; set; }
        public DbSet<Totals> Totals { get; set; }
    }
}
