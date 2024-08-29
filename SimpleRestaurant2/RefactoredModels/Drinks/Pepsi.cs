namespace SimpleRestaurant2.RefactoredModels.Drinks
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
