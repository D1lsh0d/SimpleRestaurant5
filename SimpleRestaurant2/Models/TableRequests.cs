using System.Collections;
using System.Collections.ObjectModel;

namespace SimpleRestaurant2.Models
{
    public class TableRequests : IEnumerable<Customer>
    {
        public Collection<Customer> customers;
        private bool _isCooked;
        private bool _isServed;
        private bool _isEmpty;

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
        public bool IsServed { get => _isServed; set => _isServed = value; }
        public bool IsEmpty { get => _isEmpty; private set => _isEmpty = value; }

        public TableRequests()
        {
            customers = new Collection<Customer>() { };
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
        public Collection<IMenuItem> this[string customerName] 
        {
            get 
            { 
                var customer = customers.FirstOrDefault(c => c.Name == customerName);
                
                if (customer is null)
                {
                    throw new InvalidOperationException("Customer not found");
                }
                
                return customer.Requests;
            }
        }

        public void Add(int customerId, IMenuItem menuItem)
        {
            if (customerId > 7)
            {
                throw new Exception("Can't serve more than 8 customers at once");
            }

            customers[customerId].Requests.Add(menuItem);
            IsEmpty = false;
        }

        public void Add<T>(string customerName, int? quantity = null) where T : IMenuItem
        {
            if (customers.Count > 7)
            {
                throw new Exception("Can't serve more than 8 customers at once");
            }

            var customer = customers.FirstOrDefault(c => c.Name == customerName);

            IMenuItem? menuItem;

            // Check if the type has a constructor that accepts an int (for quantity)
            var constructor = typeof(T).GetConstructor(new[] { typeof(int) });

            if (constructor != null && quantity.HasValue)
            {
                // If a constructor with int exists and quantity is provided, use it
                menuItem = (IMenuItem)constructor.Invoke(new object[] { quantity.Value });
            }
            else
            {
                // If no quantity constructor, assume a parameterless constructor exists
                menuItem = Activator.CreateInstance(typeof(T)) as IMenuItem;
            }

            if (customer is null)
            {
                // If customer doesn't exist, create a new one
                customer = new Customer(customerName);
                customers.Add(customer);
            }

            // Add the menu item request with the quantity
            customer.Requests.Add(menuItem);
        }

        public Collection<IMenuItem> Get<T>() where T : IMenuItem
        {
            Collection<IMenuItem> itemsOfType = new(customers
                .SelectMany(customer => customer.Requests)
                .Where(request => request is not null && request.GetType() == typeof(T))
                .ToList());

            return itemsOfType;
        }

        public IEnumerator<Customer> GetEnumerator()
        {
            return customers.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
