using System.Collections.ObjectModel;
using System.Linq;

namespace SimpleRestaurant2.Models
{
    public struct Customer
    {
        public string Name { get; set; }
        public Collection<IMenuItem> Requests = new Collection<IMenuItem>();

        public Customer()
        {
        }

        public void AddMenuItem(IMenuItem menuItem)
        {
            Requests.Add(menuItem);
        }
    }
}
