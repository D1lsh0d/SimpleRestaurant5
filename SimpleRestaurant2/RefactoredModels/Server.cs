using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleRestaurant2.RefactoredModels.Food;
using SimpleRestaurant2.RefactoredModels.Drinks;

namespace SimpleRestaurant2.RefactoredModels
{
    public class Server
    {
        private int _customerCount = 0;
        public int CustomerCount { get => _customerCount; }
        private TableRequests _requests;
        public Server()
        {
            _requests = new TableRequests();
        }

        public void Recieve(int chickenQuantity, int eggQuantity, Drink? beverage)
        {
            _requests.Add(_customerCount, new Chicken(chickenQuantity));
            _requests.Add(_customerCount, new Egg(eggQuantity));
            _requests.Add(_customerCount, beverage);

            _customerCount++;
        }

        public void SendRequests()
        {
            if (_requests.IsEmpty)
            {
                throw new InvalidOperationException("There weren't any valid requests yet.");
            }

            Cook.Process(_requests);
        }

        public string ServeRequests()
        {
            if (_requests.IsEmpty)
            {
                throw new InvalidOperationException("There weren't any valid requests yet.");
            }

            if (_requests.IsCooked)
            {
                throw new InvalidOperationException("Cook haven't received requests yet");
            }

            var result = new StringBuilder("\n");
            for (int i = 0; i < _customerCount; i++)
            {
                var customerRequest = _requests[i];
                result.AppendLine($"Customer {i} is served ");
                foreach (IMenuItem item in customerRequest)
                {
                    result.Append(item.Serve());
                }
            }

            return result.ToString();
        }
    }
}
