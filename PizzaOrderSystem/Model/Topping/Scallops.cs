namespace PizzaOrderSystem.Model.Topping
{
    public class Scallops
    {
        private string _name = "ホタテ";
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
