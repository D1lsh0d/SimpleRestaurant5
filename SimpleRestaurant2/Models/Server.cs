using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleRestaurant2.Models.Food;
using SimpleRestaurant2.Models.Drinks;

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

        public void Recieve(int chickenQuantity, int eggQuantity, string drinkInput)
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

            var result = new StringBuilder("\n");
            for (int i = 0; i < _customerCount; i++)
            {
                var customerRequest = _requests[i];
                var line = new StringBuilder($"Customer {i} is served ");
                foreach (IMenuItem item in customerRequest)
                {
                    line.Append(item.Serve());
                }
                result.AppendLine(line.ToString());
            }

            _requests = new TableRequests();
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
