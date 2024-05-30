namespace PizzaOrderSystem.Model.Topping
{
    public class SeafoodMix : Topping
    {
        private string _name = "シーフードミックス";
        private int _price = 500;

        public override string GetName()
        {
            return _name;
        }

        public override int GetPrice()
        {
            return _price;
        }
    }
}
