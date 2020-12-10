using Microsoft.TeamFoundation.Framework.Common;
using System;

namespace CodeAssignmentService.Shared.Providers.Abstract
{
    public interface ITimeProvider
    {
        DateTime GetToday();

        int GetDaysUntilEndOfWeek();
    }

    public class TimeProvider : ITimeProvider
    {
        public DateTime GetToday()
        {
            return DateTime.Today;
        }

        public int GetDaysUntilEndOfWeek()
        {
            var daysUntilEndOfWeek = 7 - (int)GetToday().DayOfWeek;
            return daysUntilEndOfWeek == 7 ? 0 : daysUntilEndOfWeek;
        }
    }
}