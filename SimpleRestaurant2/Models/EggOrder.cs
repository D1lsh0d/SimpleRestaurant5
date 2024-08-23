using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRestaurant2.Models
{
    public class EggOrder : Order
    {
        private int? _quality = null;
        private int _callCount = 0;
        private int rottenEggsCount = 0;
        public int RottenEggsCount { get => rottenEggsCount; }

        public EggOrder(int quantity) : base(quantity)
        {
            Random rnd = new();
            _quality = rnd.Next(101);
        }

        public int? GetQuality() 
        {
            _callCount++;

            if (_callCount % 2 == 0)
            {
                return null;
            }

            return _quality;
        }

        public void Crack()
        {
            if (GetQuality() < 25)
            {
                rottenEggsCount++;
                throw new Exception("Rotten egg");
            }
        }

        public void DiscardShell()
        {

        }
    }
}
