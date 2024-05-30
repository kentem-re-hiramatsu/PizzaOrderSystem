namespace PizzaOrderSystem.Model.Topping
{
    public class Cheese : Topping
    {
        private string _name = "チーズ";
        private int _price = 100;

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
