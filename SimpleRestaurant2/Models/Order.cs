using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRestaurant2.Models
{
    internal class Order
    {
        protected int _quantity;
        protected bool _cooked;

        public Order(int quantity)
        {
            if (quantity < 0)
            {
                throw new ArgumentOutOfRangeException("Quantity must be more than 0");
            }

            _quantity = quantity;
        }

        public int GetQuantity() => _quantity;

        public virtual void Cook()
        {
            if (_cooked)
            {
                throw new Exception("The order was already cooked");
            }

            _cooked = true;
        }
    }
}
