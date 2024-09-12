namespace SimpleRestaurant2.Models
{
    public class Customer
    {
        public string Name { get; private set; }
        public IMenuItem[] customerRequests;
        public Customer(string name)
        {
            Name = name;
            customerRequests = new IMenuItem[3];
        }

        public void AddMenuItem(IMenuItem menuItem)
        {
            for (int i = 0; i < customerRequests.Length; i++)
            {
                if (customerRequests[i] is null)
                {
                    customerRequests[i] = menuItem;
                    return;
                }
            }
        }
    }
}
