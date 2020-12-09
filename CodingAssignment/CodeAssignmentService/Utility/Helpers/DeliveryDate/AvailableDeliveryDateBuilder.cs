using System;
using System.Collections.Generic;
using System.Linq;
using CodeAssignmentService.DeliveryDate.Models.DTO;
using CodeAssignmentService.DeliveryDate.Utility.Helpers.Abstract;
using CodeAssignmentService.Shared.Providers;

namespace CodeAssignmentService.Utility.Helpers.DeliveryDate
{
    public class AvailableDeliveryDateBuilder: IAvailableDeliveryDateBuilder
    {
        public IEnumerable<AvailableDeliveryDate> GenerateAvailableDeliveryDates(int postalCode,
            IEnumerable<int> daysToDelivery) => daysToDelivery.Select(days => DateTime.Today.AddDays(days)).Select(date => new AvailableDeliveryDate()
            {
                DeliveryDate = date,
                IsGreenDelivery = GreenDatesProvider.IsDateGreen(date),
                PostalCode = postalCode
            });
        
    }
}