using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRestaurant2.RefactoredModels
{
    public class Egg : CookedFood, IDisposable
    {
        private int? _quality = null;
        private int _callCount = 0;
        private int rottenEggsCount = 0;
        private bool disposedValue;

        public int RottenEggsCount { get => rottenEggsCount; }
        public Egg(int quantity) : base(quantity)
        {
            Random rnd = new();
            _quality = rnd.Next(101);
        }

        public override void Request()
        {
            throw new NotImplementedException();
        }

        public override string Serve()
        {
            throw new NotImplementedException();
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

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    DiscardShell();
                }

                disposedValue = true;
            }
        }

        void IDisposable.Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
