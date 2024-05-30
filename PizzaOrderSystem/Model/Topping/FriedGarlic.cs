namespace PizzaOrderSystem.Model.Topping
{
    public class FriedGarlic
    {
        private string _name = "フライドガーリック";
        private int _price = 150;

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
