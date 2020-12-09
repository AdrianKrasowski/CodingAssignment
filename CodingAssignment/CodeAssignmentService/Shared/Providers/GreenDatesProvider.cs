using System;

namespace CodeAssignmentService.Shared.Providers
{
    public static class GreenDatesProvider
    {
        public static bool IsDateGreen(DateTime date) => date.DayOfWeek == DayOfWeek.Wednesday;
    }
}