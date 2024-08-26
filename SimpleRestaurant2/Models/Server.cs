using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRestaurant2.Models
{
    public class Server
    {
        private Customer[] _requests = new Customer[8];
        private int _customerCount = 0;
        public int CustomerCount { get => _customerCount; }
        private Cook _cook = new Cook();
        public Server()
        {
            
        }

        public void Recieve(int chickenQuantity, int eggQuantity, Beverage? beverage)
        {
            if (_customerCount < 8)
            {
                _requests[_customerCount] = new Customer()
                {
                    chickenOrder = new ChickenOrder(chickenQuantity),
                    eggOrder = new EggOrder(eggQuantity),
                    beverage = beverage
                };

                _customerCount++;
            }
            else { throw new InvalidOperationException("Can't serve more than 8 customers at once"); }
        }

        public string SendRequests()
        {
            if (_requests.All(request => request == null))
            {
                throw new InvalidOperationException("There weren't any valid requests yet.");
            }

            return _cook.RecieveRequests(_requests);

        }

        public string ServeRequests()
        {
            if (_requests.All(request => request == null))
            {
                throw new InvalidOperationException("There weren't any valid requests yet.");
            }

            var result = new StringBuilder("\n");
            for (int i = 0; i < _requests.Length; i++)
            {
                var customerRequest = _requests[i];

                if (customerRequest != null)
                {
                    var chickenQuantity = customerRequest.chickenOrder?.GetQuantity() ?? 0;
                    var eggQuantity = customerRequest.eggOrder?.GetQuantity() ?? 0;
                    var beverage = customerRequest.beverage?.ToString().Replace('_', ' ');

                    result.AppendLine($"Customer {i} is served {chickenQuantity} chicken, {eggQuantity} egg, {beverage}");
                }
            }

            return result.ToString();
        }
    }
}
