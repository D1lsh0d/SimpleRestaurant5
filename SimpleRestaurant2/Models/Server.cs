using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleRestaurant2.Models.Food;
using SimpleRestaurant2.Models.Drinks;
using System.Collections.ObjectModel;
using System.Net.Security;
using System.CodeDom;

namespace SimpleRestaurant2.Models
{
    public class Server
    {
        public delegate void ServerDelegate(TableRequests tableRequests);
        public event ServerDelegate Ready;

        private int _customerCount = 0;
        public int CustomerCount { get => _customerCount; }
        private TableRequests _requests;
        public string Results { get; private set; }
        public Server()
        {
            _requests = new TableRequests();
        }
        public void Subscribe(ServerDelegate serverDelegate)
        {
            Ready += serverDelegate;
        }

        public void Recieve(int chickenQuantity, int eggQuantity, string drinkInput, string customerName)
        {
            Drink drink;
            switch (drinkInput)
            {
                case "Tea":
                    drink = new Tea();
                    break;

                case "Coca-Cola":
                    drink = new CocaCola();
                    break;

                case "Pepsi":
                    drink = new Pepsi();
                    break;

                default:
                    drink = new NoDrink();
                    break;
            }

            try
            {
                _requests.customers[_customerCount].Name = customerName;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                _requests.customers.Add(new Customer(customerName));
            }

            _requests.Add(_customerCount, new Chicken(chickenQuantity));
            _requests.Add(_customerCount, new Egg(eggQuantity));
            _requests.Add(_customerCount, drink);

            _customerCount++;
        }

        public void ServeRequests()
        {
            if (_requests.IsEmpty)
            {
                throw new InvalidOperationException("There weren't any valid requests yet.");
            }

            if (_requests.IsServed)
            {
                throw new InvalidOperationException("The requests were already served!");
            }
            
            var result = new StringBuilder("\n");
            // serving drinks first
            foreach (Customer customer in _requests)
            {
                // cheking if IMenuItem object is inherited from Drink class
                var drink = customer.Requests.FirstOrDefault(drink => drink is Drink);
                var line = new StringBuilder($"Customer {customer.Name} is served {drink?.Serve()}");
                result.AppendLine(line.ToString());
            }
            // serving food
            foreach (Customer customer in _requests)
            {
                var line = new StringBuilder($"Customer {customer.Name} is served ");
                foreach (IMenuItem item in customer.Requests)
                {
                    if (item is CookedFood)
                    {
                        line.Append(item.Serve());
                    }
                }
                result.AppendLine(line.ToString());
            }

            _requests.IsServed = true;
            _customerCount = 0;
            Results = result.ToString();
        }

        public void OnServerFinishedRecording()
        {
            if (Ready is not null)
            {
                Ready?.Invoke(_requests);
            }
        }
    }
}
