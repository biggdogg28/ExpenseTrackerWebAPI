﻿using ExpenseTrackerWebAPI.Models;

namespace ExpenseTrackerWebAPI.Helpers
{
    public class ValidationFunctions
    {
        public static void ExceptionWhenDateIsNotValid(DateTime? start, DateTime? end)
        {
            if (start.HasValue && end.HasValue && start > end)
            {
                throw new ModelValidationException(Helpers.ErrorMessagesEnum.StartEndDatesError);
            }
        }
    }
}
