namespace SimpleRestaurant2.RefactoredModels
{
    public struct Customer
    {
        public IMenuItem[] customerRequests = new IMenuItem[3];

        public Customer()
        {
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
