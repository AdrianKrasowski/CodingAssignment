using System;
using System.Collections.Generic;
using System.Text;

namespace CodeAssignmentService.Models
{
    public class ProductDTO
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public IEnumerable<DayOfWeek> DeliveryDays { get; set; }
        public string ProductType { get; set; }
        public int DaysInAdvance { get; set; }

    }
}
