namespace PizzaOrderSystem.Model.Topping
{
    public class Bacon : Topping
    {
        private string _name = "ベーコン";
        private int _price = 250;

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
