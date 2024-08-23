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
            else { throw new Exception("Can't serve more than 8 customers at once"); }
        }

        public void SendRequests()
        {
            _cook.RecieveRequests(_requests);
        }
    }
}
