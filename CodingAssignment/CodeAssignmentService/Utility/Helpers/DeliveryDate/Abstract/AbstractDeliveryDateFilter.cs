using System;
using System.Collections.Generic;
using System.Linq;
using CodeAssignmentService.Shared.Providers;
using CodeAssignmentService.Shared.Providers.Abstract;

namespace CodeAssignmentService.DeliveryDate.Utility.Helpers.Abstract
{
    public abstract class AbstractDeliveryDateFilter
    {
        protected ITimeProvider _timeProvider;

        public AbstractDeliveryDateFilter(ITimeProvider timeProvider)
        {
            _timeProvider = timeProvider;
        }

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