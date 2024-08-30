using SimpleRestaurant2.Models.Food;

namespace SimpleRestaurant2.Models
{
    public static class Cook
    {
        public static void Process(TableRequests requests)
        {
            if (requests.IsCooked)
            {
                throw new Exception("Order for that table was already cooked");
            }

            IMenuItem[] chickens = requests[typeof(Chicken)];
            IMenuItem[] eggs = requests[typeof(Egg)];

            foreach (Chicken chicken in chickens) 
            {
                chicken.CutUp();
                chicken.Cook();
            }

            foreach (Egg egg in eggs)
            {
                using (egg)
                {
                    egg.Crack();
                    egg.DiscardShell();
                    egg.Cook();
                }
            }

            requests.IsCooked = true;
        }
    }
}
