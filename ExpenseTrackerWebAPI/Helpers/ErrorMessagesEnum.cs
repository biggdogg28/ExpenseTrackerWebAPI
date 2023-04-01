namespace ExpenseTrackerWebAPI.Helpers
{
    public static class ErrorMessagesEnum
    {
        public const string NoElementFound = "No element found in the table!";
        public const string StartEndDatesError = "End date cannot occur before the Start date";
        public const string BadRequest = "Body is not correct!";
    }
}
