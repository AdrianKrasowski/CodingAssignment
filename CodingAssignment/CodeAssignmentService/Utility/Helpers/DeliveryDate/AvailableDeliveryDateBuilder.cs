using System;
using System.Collections.Generic;
using System.Linq;
using CodeAssignmentService.DeliveryDate.Models.DTO;
using CodeAssignmentService.DeliveryDate.Utility.Helpers.Abstract;
using CodeAssignmentService.Shared.Providers;
using CodeAssignmentService.Shared.Providers.Abstract;

namespace CodeAssignmentService.Utility.Helpers.DeliveryDate
{
    public class AvailableDeliveryDateBuilder: IAvailableDeliveryDateBuilder
    {
        private readonly ITimeProvider _timeProvider;

        public AvailableDeliveryDateBuilder(ITimeProvider timeProvider)
        {
            _timeProvider = timeProvider;
        }

        public IEnumerable<AvailableDeliveryDate> GenerateAvailableDeliveryDates(int postalCode,
            IEnumerable<int> daysToDelivery) => daysToDelivery.Select(days => _timeProvider.GetToday().AddDays(days)).Select(date => new AvailableDeliveryDate()
            {
                DeliveryDate = date,
                IsGreenDelivery = GreenDatesProvider.IsDateGreen(date),
                PostalCode = postalCode
            });
        
    }
}