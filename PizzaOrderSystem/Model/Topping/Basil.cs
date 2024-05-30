namespace PizzaOrderSystem.Model.Topping
{
    public class Basil : Topping
    {
        private string _name = "バジル";
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
