namespace PizzaOrderSystem.Model.Topping
{
    public class Tuna : Topping
    {
        private string _name = "ツナ";
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
