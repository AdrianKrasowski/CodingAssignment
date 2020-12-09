using System.Collections.Generic;
using CodeAssignmentService.Models;

namespace CodeAssignmentService.DeliveryDate.Models.Request
{
    public class AvailableDeliveryDateQuery
    {
        public int PostalCode { get; set; }

        public IEnumerable<ProductDTO> Products { get; set; }
    }
}