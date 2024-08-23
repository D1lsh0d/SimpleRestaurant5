namespace SimpleRestaurant2.Models
{
    public class Customer
    {
        public ChickenOrder? chickenOrder;
        public EggOrder? eggOrder;
        public Beverage? beverage;

        public Customer()
        {
        }

        public Customer(ChickenOrder? chickenOrder, EggOrder? eggOrder, Beverage? beverage) { 
            this.beverage = beverage;
            this.eggOrder = eggOrder;
            this.chickenOrder = chickenOrder;
        }
    }
}
