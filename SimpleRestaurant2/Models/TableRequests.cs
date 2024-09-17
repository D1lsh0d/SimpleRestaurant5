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

        public IMenuItem[] this[Type type]
        {
            get
            {
                IMenuItem[] itemsOfType = new IMenuItem[8];     //temp array
                int count = 0;  //count of same type objects

                foreach (var customer in customers)
                {
                    foreach (var request in customer.customerRequests)
                    {
                        if (request is not null && request.GetType() == type)
                        {
                            itemsOfType[count++] = request;     //filling temp array with same type objects
                        }
                    }
                }

                IMenuItem[] result = new IMenuItem[count];      
                Array.Copy(itemsOfType, result, count);         //copying non-null objects to a new array
                return result;
            }
        }
        public IMenuItem[] this[int customer] => customers[customer].customerRequests;

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
