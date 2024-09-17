using System.Collections.ObjectModel;

namespace SimpleRestaurant2.Models
{
    public class TableRequests
    {
        public Customer[] customers;
        private bool _isCooked;
        public bool IsCooked
        {
            get => _isCooked;
            set
            {
                if (value != false)
                {
                    _isCooked = value;
                }
            }
        }
        public bool IsServed { get; set; }
        private bool _isEmpty = true;
        public bool IsEmpty { get => _isEmpty; }
        
        public TableRequests()
        {
            customers = new Customer[8];
            // inizializing customers
            for (int i = 0; i < 8; i++)
            {
                customers[i] = new Customer();
            }
        }

        public Collection<IMenuItem> this[Type type]
        {
            get
            {
                Collection<IMenuItem> itemsOfType = new();     //temp array

                foreach (var customer in customers)
                {
                    foreach (var request in customer.Requests)
                    {
                        if (request is not null && request.GetType() == type)
                        {
                            itemsOfType.Add(request);     //filling temp array with same type objects
                        }
                    }
                }

                return itemsOfType;
            }
        }
        public Collection<IMenuItem> this[int Id] => customers[Id].Requests;

        public void Add(int customer, IMenuItem menuItem)
        {
            if (customer >= 8)
            {
                throw new Exception("Can't serve more than 8 customers at once");
            }
            
            customers[customer].AddMenuItem(menuItem);
            _isEmpty = false;
        }
    }
}
