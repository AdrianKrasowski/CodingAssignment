using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using CodeAssignmentService.DeliveryDate.Enums;
using CodeAssignmentService.DeliveryDate.Utility.Factories;
using CodeAssignmentService.DeliveryDate.Utility.Helpers.Abstract;
using CodeAssignmentService.Models;
using CodeAssignmentService.Shared.Providers;
using CodeAssignmentService.Shared.Providers.Abstract;
using Microsoft.VisualStudio.Services.CircuitBreaker;

namespace CodeAssignmentService.DeliveryDate.Models
{
    public class ProductDeliveryDates
    {
        private AbstractDeliveryDateFilter dateFilter;
        private IEnumerable<int> _daysUntilDelivery;


        public ProductDeliveryDates(ProductDTO product, ITimeProvider time)
        {
            dateFilter = DeliveryDateFilterFactory.GenerateFilterForProductType(product.ProductType, time);
            _daysUntilDelivery = dateFilter.FilterAvailableDeliveryDates(product.DeliveryDays, product.DaysInAdvance)
                .Select(date => (int) (date - time.GetToday()).TotalDays);
        }

        public IEnumerable<int> DaysUntilDelivery
        {
            get => _daysUntilDelivery;
        }
    }
}
