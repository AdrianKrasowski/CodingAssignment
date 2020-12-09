using CodeAssignmentService.DeliveryDate.Enums;
using CodeAssignmentService.DeliveryDate.Models;
using CodeAssignmentService.DeliveryDate.Utility.Helpers.Abstract;
using CodeAssignmentService.DeliveryDate.Utility.Helpers.Filters;

namespace CodeAssignmentService.DeliveryDate.Utility.Factories
{
    public static class DeliveryDateFilterFactory
    {
        public static AbstractDeliveryDateFilter GenerateFilterForProductType(string productType)
        {
            switch (productType.ToLower())
            {
                case ProductTypes.External:
                    return new ExternalProductDeliveryDateFilter();
                case ProductTypes.Internal:
                    return new InternalProductDeliveryDateFilter();
                case ProductTypes.Temporary:
                    return new TemporaryProductDeliveryDateFilter();
                default:
                    return new InternalProductDeliveryDateFilter();
            }
        }
    }
}