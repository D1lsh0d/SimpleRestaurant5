using SimpleRestaurant2.Models.Food;
using System.Collections.ObjectModel;
using static SimpleRestaurant2.Models.Server;

namespace SimpleRestaurant2.Models
{
    public class Cook
    {
        
        public delegate void CookDelegate();
        public event CookDelegate Processed;

        public Cook()
        {
            
        }
        public void Subscribe(CookDelegate cookDelegate) 
        {
            Processed += cookDelegate;
        }

        public void Process(TableRequests requests)
        {
            if (requests.IsCooked)
            {
                throw new Exception("Order for that table was already cooked");
            }

            Collection<IMenuItem> chickens = requests.Get<Chicken>();
            Collection<IMenuItem> eggs = requests.Get<Egg>();

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
            Processed?.Invoke();
        }
    }
}
