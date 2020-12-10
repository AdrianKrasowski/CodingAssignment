using System;
using System.Collections.Generic;

namespace CodeAssignmentService.DeliveryDate.Models.DTO
{
    public class AvailableDeliveryDate
    {
        public int PostalCode { get; set; }
        public DateTime DeliveryDate { get; set; }
        public bool IsGreenDelivery { get; set; }

        public override bool Equals(object obj)
        {
            var availableDeliveryDate = obj as AvailableDeliveryDate;
            return availableDeliveryDate != null &&
                   PostalCode == availableDeliveryDate.PostalCode &&
                   DeliveryDate == availableDeliveryDate.DeliveryDate &&
                    IsGreenDelivery == availableDeliveryDate.IsGreenDelivery;
        }
        public override int GetHashCode()
        {
            return -1848057237 + PostalCode.GetHashCode() + DeliveryDate.GetHashCode()+ IsGreenDelivery.GetHashCode();
        }

        public static bool operator ==(AvailableDeliveryDate availableDeliveryDate1, AvailableDeliveryDate availableDeliveryDate2)
        {
            return EqualityComparer<AvailableDeliveryDate>.Default.Equals(availableDeliveryDate1, availableDeliveryDate2);
        }

        public static bool operator !=(AvailableDeliveryDate availableDeliveryDate1, AvailableDeliveryDate availableDeliveryDate2)
        {
            return !(availableDeliveryDate1 == availableDeliveryDate2);
        }
    }
}