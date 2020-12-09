using System.Collections.Generic;
using CodeAssignmentService.DeliveryDate.Models.DTO;

namespace CodeAssignmentService.DeliveryDate.Utility.Helpers.Abstract
{
    public interface IAvailableDeliveryDateBuilder
    {
        IEnumerable<AvailableDeliveryDate> GenerateAvailableDeliveryDates(int postalCode,
            IEnumerable<int> daysToDelivery);
    }
}