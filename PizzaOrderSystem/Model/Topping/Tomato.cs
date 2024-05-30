namespace PizzaOrderSystem.Model.Topping
{
    public class Tomato
    {
        private string _name = "トマト";
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
