using System.Collections.Generic;
using System.Linq;
using CodeAssignmentService.DeliveryDate.Models.DTO;
using CodeAssignmentService.DeliveryDate.Services.Abstract;
using CodeAssignmentService.DeliveryDate.Utility.Helpers.Abstract;
using CodeAssignmentService.Models;
using CodeAssignmentService.Shared.Providers;
using CodeAssignmentService.Shared.Providers.Abstract;
using CodeAssignmentService.Utility.Helpers.DeliveryDate;

namespace CodeAssignmentService.DeliveryDate.Models.Services
{
    public class DeliveryDateScheduleService : IDeliveryDateScheduleService
    {
        private readonly IAvailableDeliveryDateBuilder _deliveryDateBuilder;
        private readonly ITimeProvider _timeProvider;

        public DeliveryDateScheduleService(IAvailableDeliveryDateBuilder deliveryDateBuilder, ITimeProvider timeProvider)
        {
            _deliveryDateBuilder = deliveryDateBuilder;
            _timeProvider = timeProvider;
        }
        public IEnumerable<AvailableDeliveryDate> CalculateAvailableDeliveryDatesForProducts(int postalCode,
            IEnumerable<ProductDTO> orderedProducts)
        {
            NextTwoWeeksDateProvider.GenerateTimeSpan(_timeProvider);

            var daysToPossibleDeliveryOfProducts =
                orderedProducts.Select(product => new ProductDeliveryDates(product,_timeProvider).DaysUntilDelivery);

            if (!daysToPossibleDeliveryOfProducts.Any() || daysToPossibleDeliveryOfProducts.Any(x => !x.Any()))
                return null;

            return _deliveryDateBuilder.GenerateAvailableDeliveryDates(postalCode,
                new DeliveryDateDictionary(daysToPossibleDeliveryOfProducts).DaysToDelivery);

        }
    }
}