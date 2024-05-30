namespace PizzaOrderSystem.Model.Topping
{
    public class Cheese
    {
        private string _name = "チーズ";
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
