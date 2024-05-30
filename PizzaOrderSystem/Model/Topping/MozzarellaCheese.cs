namespace PizzaOrderSystem.Model.Topping
{
    public class MozzarellaCheese
    {
        private string _name = "モッツァレラチーズ";
        private int _price = 300;

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
