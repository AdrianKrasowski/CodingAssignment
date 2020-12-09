using System;
using System.Collections.Generic;
using CodeAssignmentService.DeliveryDate.Utility.Helpers.Abstract;
using CodeAssignmentService.Shared.Providers;

namespace CodeAssignmentService.DeliveryDate.Utility.Helpers.Filters
{
    public class InternalProductDeliveryDateFilter: AbstractDeliveryDateFilter
    {
        public override IEnumerable<DateTime> FilterAvailableDeliveryDates(IEnumerable<DayOfWeek> deliveryDays, int daysInAdvance)
        {
            return FilterByWeekdays(deliveryDays, daysInAdvance, NextTwoWeeksDateProvider.DatesInNextTwoWeeks);
        }
    }
}