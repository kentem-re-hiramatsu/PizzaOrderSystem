namespace PizzaOrderSystem.Model.Topping
{
    public class Tuna
    {
        private string _name = "ツナ";
        private int _price = 250;

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
