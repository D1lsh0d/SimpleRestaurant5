using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRestaurant2.Models
{
    public class ChickenOrder : Order
    {
        public ChickenOrder(int quantity) : base(quantity)
        {

        }

        public void CutUp()
        {

        }
    }
}
