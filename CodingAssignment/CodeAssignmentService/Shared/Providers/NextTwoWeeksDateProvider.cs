using System;
using System.Collections.Generic;
using System.Linq;
using CodeAssignmentService.Shared.Providers.Abstract;

namespace CodeAssignmentService.Shared.Providers
{
    public static class NextTwoWeeksDateProvider
    {
        private static IEnumerable<DateTime> _datesInNextTwoWeeks = new List<DateTime>();
        public static IEnumerable<DateTime> DatesInNextTwoWeeks
        {
            get => _datesInNextTwoWeeks;
        }

        public static void GenerateTimeSpan(ITimeProvider timeProvider)
        {
            var lastDay = timeProvider.GetToday().AddDays(14);
            var startDate = timeProvider.GetToday();
            _datesInNextTwoWeeks = Enumerable.Range(0, 1 + lastDay.Subtract(startDate).Days)
                .Select(offset => startDate.AddDays(offset))
                .ToList();
        }
    }
}