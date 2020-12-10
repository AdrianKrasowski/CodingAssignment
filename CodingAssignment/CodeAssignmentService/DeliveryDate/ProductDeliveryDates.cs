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
    public enum ProductType
    {
        External,
        Internal,
        Temporal,
        Unknown
    }
    public class ProductDeliveryDates
    {
        private int _productId;
        private string _name;
        private AbstractDeliveryDateFilter dateFilter;
        private IEnumerable<int> _daysUntilDelivery;

        private IEnumerable<DateTime> suggestedDeliveryDates;

        public ProductDeliveryDates(ProductDTO product, ITimeProvider time)
        {
            _productId = product.ProductId;
            _name = product.Name;
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
