namespace SimpleRestaurant4.Models.Drinks
{
    public sealed class Pepsi : Drink
    {
        public override void Request()
        {
            throw new NotImplementedException();
        }

        public override string Serve()
        {
            return "Pepsi";
        }
    }
}
