namespace PizzaOrderSystem.Model.Topping
{
    public class MozzarellaCheese : Topping
    {
        private string _name = "モッツァレラチーズ";
        private int _price = 300;

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
