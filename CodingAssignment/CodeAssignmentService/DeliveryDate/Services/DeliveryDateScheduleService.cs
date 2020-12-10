using System.Collections.Generic;
using System.Linq;
using CodeAssignmentService.DeliveryDate.Models.DTO;
using CodeAssignmentService.DeliveryDate.Services.Abstract;
using CodeAssignmentService.DeliveryDate.Utility.Helpers.Abstract;
using CodeAssignmentService.Models;
using CodeAssignmentService.Product.Validator.Abstract;
using CodeAssignmentService.Shared.Providers;
using CodeAssignmentService.Shared.Providers.Abstract;
using CodeAssignmentService.Utility.Helpers.DeliveryDate;

namespace CodeAssignmentService.DeliveryDate.Models.Services
{
    public class DeliveryDateScheduleService : IDeliveryDateScheduleService
    {
        private readonly IAvailableDeliveryDateBuilder _deliveryDateBuilder;
        private readonly IProductValidator _productValidator;
        private readonly ITimeProvider _timeProvider;

        public DeliveryDateScheduleService(IAvailableDeliveryDateBuilder deliveryDateBuilder, ITimeProvider timeProvider, IProductValidator productValidator)
        {
            _deliveryDateBuilder = deliveryDateBuilder;
            _timeProvider = timeProvider;
            _productValidator = productValidator;
        }
        public IEnumerable<AvailableDeliveryDate> CalculateAvailableDeliveryDatesForProducts(int postalCode,
            IEnumerable<ProductDTO> orderedProducts)
        {
            NextTwoWeeksDateProvider.GenerateTimeSpan(_timeProvider);

            if (!_productValidator.AreValid(orderedProducts))
                return new List<AvailableDeliveryDate>();

            var daysToPossibleDeliveryOfProducts =
                orderedProducts.Select(product => new ProductDeliveryDates(product,_timeProvider).DaysUntilDelivery);

            if (!daysToPossibleDeliveryOfProducts.Any() || daysToPossibleDeliveryOfProducts.Any(x => !x.Any()))
                return new List<AvailableDeliveryDate>();

            return _deliveryDateBuilder.GenerateAvailableDeliveryDates(postalCode,
                new DeliveryDateDictionary(daysToPossibleDeliveryOfProducts).DaysToDelivery);

        }

        
    }
}