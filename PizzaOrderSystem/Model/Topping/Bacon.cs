namespace PizzaOrderSystem.Model.Topping
{
    public class Bacon
    {
        private string _name = "ベーコン";
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
