using System.Collections.ObjectModel;
using System.Linq;

namespace SimpleRestaurant4.Models
{
    public class Customer
    {
        public string Name { get; set; }
        public Collection<IMenuItem> Requests = new Collection<IMenuItem>();

        public Customer(string name)
        {
            Name = name;
        }
    }
}
