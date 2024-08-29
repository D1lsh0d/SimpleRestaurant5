namespace SimpleRestaurant2.RefactoredModels.Drinks
{
    public class Tea : Drink
    {
        public override void Request()
        {
            throw new NotImplementedException();
        }

        public override string Serve()
        {
            return "Tea";
        }
    }
}
