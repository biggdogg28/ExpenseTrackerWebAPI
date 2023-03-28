namespace ExpenseTrackerWebAPI.Models
{
    public class ModelValidationExceptions : Exception
    {
        public ModelValidationExceptions(string message) : base(message) { }
    }
}
