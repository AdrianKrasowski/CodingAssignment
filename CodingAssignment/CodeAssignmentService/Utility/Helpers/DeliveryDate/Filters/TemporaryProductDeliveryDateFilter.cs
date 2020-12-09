using System;
using System.Collections.Generic;
using System.Linq;
using CodeAssignmentService.DeliveryDate.Utility.Helpers.Abstract;
using CodeAssignmentService.Shared.Providers;

namespace CodeAssignmentService.DeliveryDate.Utility.Helpers.Filters
{
    public class TemporaryProductDeliveryDateFilter: AbstractDeliveryDateFilter
    {
        public override IEnumerable<DateTime> FilterAvailableDeliveryDates(IEnumerable<DayOfWeek> deliveryDays, int daysInAdvance)
        {
            return FilterByWeekdays(deliveryDays, daysInAdvance, NextTwoWeeksDateProvider.DatesInNextTwoWeeks.Take(GetDaysUntilEndOfTheWeek(DateTime.Today.DayOfWeek) + 1));
        }

        public int GetDaysUntilEndOfTheWeek(DayOfWeek day)
        {
            var daysUntilEndOfWeek = 7 - (int)day;
            return daysUntilEndOfWeek == 7 ? 0 : daysUntilEndOfWeek;
        }
    }
}