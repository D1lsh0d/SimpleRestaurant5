namespace SimpleRestaurant4.Models.Food
{
    public sealed class Chicken : CookedFood, IMenuItem
    {
        public Chicken(int quantity) : base(quantity) { }
        public override void Cook()
        {
            for (int i = 0; i < _quantity; i++)
            {
                CutUp();
            }

            base.Cook();
        }

        public override string Serve()
        {
            return $"{_quantity} chicken, ";
        }

        public void CutUp()
        {

        }

        public override void Request()
        {
            throw new NotImplementedException();
        }
    }
}
