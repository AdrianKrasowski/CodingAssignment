using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CodeAssignmentService.Utility.Helpers.DeliveryDate
{
    public class DeliveryDateDictionary
    {
        private IDictionary<int, int> _deliveryDateDictionary;
        private int numberOfProducts;

        public IEnumerable<int> DaysToDelivery
        {
            get => _deliveryDateDictionary.Where(x => x.Value == numberOfProducts).Select(x => x.Key);
        } 

        public DeliveryDateDictionary(IEnumerable<IEnumerable<int>> listOfDaysToAvailableDeliveryDateForEachProduct)
        {
            _deliveryDateDictionary = new Dictionary<int, int>();
            InitializeDictionary();
            numberOfProducts = listOfDaysToAvailableDeliveryDateForEachProduct.Count();

            foreach (var listOfDaysToAvailableDeliveryDateForProduct in listOfDaysToAvailableDeliveryDateForEachProduct)
            {
                RegisterDeliveryDaysInDictionary(listOfDaysToAvailableDeliveryDateForProduct);
            }
            
        }

        private void InitializeDictionary()
        {
            for (int i = 0; i <= 14; i++)
            {
                _deliveryDateDictionary.Add(i, 0);
            }
        }

        private void RegisterDeliveryDaysInDictionary(IEnumerable<int> listOfDaysToAvailableDeliveryDateForProduct)
        {
            foreach (int daysToAvailableDeliveryDate in listOfDaysToAvailableDeliveryDateForProduct)
            {
                _deliveryDateDictionary[daysToAvailableDeliveryDate] = _deliveryDateDictionary[daysToAvailableDeliveryDate] + 1;
            }
        }



    }
}