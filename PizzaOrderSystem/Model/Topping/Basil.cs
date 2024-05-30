namespace PizzaOrderSystem.Model.Topping
{
    public class Basil
    {
        private string _name = "バジル";
        private int _price = 100;

        public string GetName()
        {
            return _name;
        }

        public int GetPrice()
        {
            return _price;
        }
    }
}
