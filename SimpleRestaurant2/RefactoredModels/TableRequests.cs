using System.Runtime.CompilerServices;

namespace SimpleRestaurant2.RefactoredModels
{
    public class TableRequests
    {
        public Customer[] customers = new Customer[8];
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
            customers[customer].AddMenuItem(menuItem);
        }
    }
}
