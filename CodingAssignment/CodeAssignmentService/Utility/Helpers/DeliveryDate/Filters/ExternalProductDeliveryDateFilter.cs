using System;
using System.Collections.Generic;
using CodeAssignmentService.DeliveryDate.Utility.Helpers.Abstract;
using CodeAssignmentService.Shared.Providers;

namespace CodeAssignmentService.DeliveryDate.Utility.Helpers.Filters
{
    public class ExternalProductDeliveryDateFilter: AbstractDeliveryDateFilter
    {
        public override IEnumerable<DateTime> FilterAvailableDeliveryDates(IEnumerable<DayOfWeek> deliveryDays, int daysInAdvance)
        {
            if (daysInAdvance < 5)
                daysInAdvance = 5;
            return FilterByWeekdays(deliveryDays, daysInAdvance, NextTwoWeeksDateProvider.DatesInNextTwoWeeks);
        }
    }
}