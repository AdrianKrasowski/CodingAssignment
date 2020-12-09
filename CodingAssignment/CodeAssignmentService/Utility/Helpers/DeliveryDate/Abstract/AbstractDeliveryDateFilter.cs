using System;
using System.Collections.Generic;
using System.Linq;
using CodeAssignmentService.Shared.Providers;

namespace CodeAssignmentService.DeliveryDate.Utility.Helpers.Abstract
{
    public abstract class AbstractDeliveryDateFilter
    {
        protected IEnumerable<DateTime> FilterByWeekdays(IEnumerable<DayOfWeek> deliveryDays, int daysInAdvance, IEnumerable<DateTime> dateRange)
        {
            if(dateRange.Count()<daysInAdvance)
                return new List<DateTime>();
            return dateRange.Skip(daysInAdvance).Where(date => deliveryDays.Contains(date.DayOfWeek));
        }

        public abstract IEnumerable<DateTime> FilterAvailableDeliveryDates(IEnumerable<DayOfWeek> deliveryDays,
            int daysInAdvance);
    }
}