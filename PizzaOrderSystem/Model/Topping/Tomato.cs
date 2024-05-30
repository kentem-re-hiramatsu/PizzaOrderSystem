namespace PizzaOrderSystem.Model.Topping
{
    public class Tomato : Topping
    {
        private string _name = "トマト";
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
