using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRestaurant2.RefactoredModels
{
    public abstract class Drink : IMenuItem
    {
        public abstract void Request();
        public abstract string Serve();

        IMenuItem IMenuItem.Obtain()
        {
            throw new NotImplementedException();
        }
    }
}
