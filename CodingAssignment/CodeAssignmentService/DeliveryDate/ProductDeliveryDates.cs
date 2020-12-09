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

        public ProductDeliveryDates(ProductRequest product)
        {
            _productId = product.ProductId;
            _name = product.Name;
            dateFilter = DeliveryDateFilterFactory.GenerateFilterForProductType(product.ProductType);
            _daysUntilDelivery = dateFilter.FilterAvailableDeliveryDates(product.DeliveryDays, product.DaysInAdvance)
                .Select(date => (int) (date - DateTime.Today).TotalDays);
        }

        public IEnumerable<int> DaysUntilDelivery
        {
            get => _daysUntilDelivery;
        }
    }
}
