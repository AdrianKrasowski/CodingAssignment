using System.Collections.Generic;
using System.Linq;
using CodeAssignmentService.DeliveryDate.Enums;
using CodeAssignmentService.Models;
using CodeAssignmentService.Product.Validator.Abstract;
using CodeAssignmentService.Shared.Providers.Abstract;
using CodeAssignmentService.Utility.Helpers.DeliveryDate;
using Microsoft.VisualStudio.Services.CircuitBreaker;

namespace CodeAssignmentService.Product.Validator
{
    public class ProductValidator : IProductValidator
    {
        private readonly ITimeProvider _timeProvider;

        public ProductValidator(ITimeProvider timeProvider)
        {
            _timeProvider = timeProvider;
        }

        public bool AreValid(IEnumerable<ProductDTO> products)
        {
            return CommonDeliveryDayExist(products) && ValidateTemporaryProducts(products);
        }

        private bool ValidateTemporaryProducts(IEnumerable<ProductDTO> products)
        {
            foreach (var product in products)
            {
                if (product.ProductType.ToLower() == ProductTypes.Temporary)
                {
                    if (product.DaysInAdvance > _timeProvider.GetDaysUntilEndOfWeek())
                        return false;
                }
            }
            return true;
        }

        private bool CommonDeliveryDayExist(IEnumerable<ProductDTO> productList)
        {
            var result= new DeliveryDateDictionary(productList.Select(p => p.DeliveryDays.Select(d => (int)d))).DaysToDelivery.Any();
            return result;
        }

    }
}