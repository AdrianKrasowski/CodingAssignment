using System;

namespace CodeAssignmentService.DeliveryDate.Models.DTO
{
    public class AvailableDeliveryDate
    {
        public int PostalCode { get; set; }
        public DateTime DeliveryDate { get; set; }
        public bool IsGreenDelivery { get; set; }
    }
}