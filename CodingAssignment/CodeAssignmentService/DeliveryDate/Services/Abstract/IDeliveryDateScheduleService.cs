using System.Collections.Generic;
using CodeAssignmentService.DeliveryDate.Models.DTO;
using CodeAssignmentService.Models;

namespace CodeAssignmentService.DeliveryDate.Services.Abstract
{
    public interface IDeliveryDateScheduleService
    {
        IEnumerable<AvailableDeliveryDate> CalculateAvailableDeliveryDatesForProducts(int postalCode,
            IEnumerable<ProductRequest> orderedProducts);
    }
}