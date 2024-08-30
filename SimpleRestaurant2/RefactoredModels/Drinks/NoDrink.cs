namespace SimpleRestaurant2.RefactoredModels.Drinks
{
    public class NoDrink : Drink
    {
        public override void Request()
        {
            throw new NotImplementedException();
        }

        public override string Serve()
        {
            return "no drink";
        }
    }
}