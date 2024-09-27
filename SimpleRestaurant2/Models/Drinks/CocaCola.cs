namespace SimpleRestaurant4.Models.Drinks
{
    public sealed class CocaCola : Drink
    {
        public override void Request()
        {
            throw new NotImplementedException();
        }

        public override string Serve()
        {
            return "Coca-Cola";
        }
    }
}
