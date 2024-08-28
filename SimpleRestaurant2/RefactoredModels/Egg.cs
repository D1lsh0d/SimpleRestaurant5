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
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~Egg()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        void IDisposable.Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
