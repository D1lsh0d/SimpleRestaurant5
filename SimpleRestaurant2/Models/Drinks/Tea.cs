namespace SimpleRestaurant4.Models.Drinks
{
    public class Tea : Drink
    {
        public Tea()
        {
            
        }
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
