using SimpleRestaurant2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRestaurant2.RefactoredModels.Food
{
    public sealed class Chicken : CookedFood
    {
        public Chicken(int quantity) : base(quantity) { }
        public override void Cook()
        {
            for (int i = 0; i < _quantity; i++)
            {
                CutUp();
            }

            base.Cook();
        }

        public override string Serve()
        {
            return $"{_quantity} chicken was cooked";
        }

        public void CutUp()
        {

        }

        public override void Request()
        {
            throw new NotImplementedException();
        }
    }
}
