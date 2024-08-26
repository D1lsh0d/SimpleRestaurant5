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
        private bool _isPrepared;
        public bool IsPrepared { get => _isPrepared; }
        public Cook()
        {
            
        }

        public void RecieveRequests(Customer[] requests)
        {
            _requests = requests;
            PrepareFood();
        }

        private void PrepareFood()
        {
            foreach (Customer customerRequest in _requests)
            {
                customerRequest?.eggOrder?.Cook();
                customerRequest?.chickenOrder?.Cook();
            }

            _isPrepared = true;
        }
    }
}
