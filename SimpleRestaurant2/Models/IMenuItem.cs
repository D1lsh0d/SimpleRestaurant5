using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRestaurant2.Models
{
    public interface IMenuItem
    {
        public void Request();
        public IMenuItem Obtain();
        public string Serve();
    }
}
