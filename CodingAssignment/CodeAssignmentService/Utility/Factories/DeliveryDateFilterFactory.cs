using CodeAssignmentService.DeliveryDate.Enums;
using CodeAssignmentService.DeliveryDate.Models;
using CodeAssignmentService.DeliveryDate.Utility.Helpers.Abstract;
using CodeAssignmentService.DeliveryDate.Utility.Helpers.Filters;
using CodeAssignmentService.Shared.Providers.Abstract;

namespace CodeAssignmentService.DeliveryDate.Utility.Factories
{
    public static class DeliveryDateFilterFactory
    {
        public static AbstractDeliveryDateFilter GenerateFilterForProductType(string productType, ITimeProvider _timeProvider)
        {
            switch (productType.ToLower())
            {
                case ProductTypes.External:
                    return new ExternalProductDeliveryDateFilter(_timeProvider);
                case ProductTypes.Internal:
                    return new InternalProductDeliveryDateFilter(_timeProvider);
                case ProductTypes.Temporary:
                    return new TemporaryProductDeliveryDateFilter(_timeProvider);
                default:
                    return new InternalProductDeliveryDateFilter(_timeProvider);
            }
        }
    }
}