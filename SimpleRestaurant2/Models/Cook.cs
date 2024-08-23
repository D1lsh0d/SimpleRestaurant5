using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRestaurant2.Models
{
    public class Cook
    {
        private Customer[] _requests = new Customer[8];

        public Cook()
        {
            
        }

        public string RecieveRequests(Customer[] requests)
        {
            _requests = requests;
            return "Requests were received by cook";
        }

        public string PrepareFood()
        {
            for (int i = 0; i < _requests.Length; i++)
            {
                if (_requests[i].eggOrder is not null)
                {
                    _requests[i].eggOrder.Cook();
                }
                if (_requests[i].chickenOrder is not null)
                {
                    _requests[i].chickenOrder.Cook();
                }
            }
        }
    }
}
