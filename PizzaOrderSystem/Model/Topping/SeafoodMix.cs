namespace PizzaOrderSystem.Model.Topping
{
    public class SeafoodMix
    {
        private string _name = "シーフードミックス";
        private int _price = 500;

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
