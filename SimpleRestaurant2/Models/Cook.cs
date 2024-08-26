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
            PrepareFood();
            return "\nRequests were prepared by cook";
        }

        private void PrepareFood()
        {
            foreach (Customer customerRequest in _requests)
            {
                customerRequest?.eggOrder?.Cook();
                customerRequest?.chickenOrder?.Cook();
            }
        }
    }
}
