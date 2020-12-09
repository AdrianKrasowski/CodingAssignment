using System.Collections.Generic;
using System.Linq;
using CodeAssignmentService.DeliveryDate.Models.DTO;
using CodeAssignmentService.DeliveryDate.Services.Abstract;
using CodeAssignmentService.DeliveryDate.Utility.Helpers.Abstract;
using CodeAssignmentService.Models;
using CodeAssignmentService.Shared.Providers;
using CodeAssignmentService.Utility.Helpers.DeliveryDate;

namespace CodeAssignmentService.DeliveryDate.Models.Services
{
    public class DeliveryDateScheduleService : IDeliveryDateScheduleService
    {
        private readonly IAvailableDeliveryDateBuilder _deliveryDateBuilder;

        public DeliveryDateScheduleService(IAvailableDeliveryDateBuilder deliveryDateBuilder)
        {
            _deliveryDateBuilder = deliveryDateBuilder;
        }
        public IEnumerable<AvailableDeliveryDate> CalculateAvailableDeliveryDatesForProducts(int postalCode,
            IEnumerable<ProductDTO> orderedProducts)
        {
            NextTwoWeeksDateProvider.GenerateTimeSpan();

            var daysToPossibleDeliveryOfProducts =
                orderedProducts.Select(product => new ProductDeliveryDates(product).DaysUntilDelivery);

            if (!daysToPossibleDeliveryOfProducts.Any() || daysToPossibleDeliveryOfProducts.Any(x => !x.Any()))
                return null;

            return _deliveryDateBuilder.GenerateAvailableDeliveryDates(postalCode,
                new DeliveryDateDictionary(daysToPossibleDeliveryOfProducts).DaysToDelivery);

        }
    }
}