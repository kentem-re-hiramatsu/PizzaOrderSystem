namespace PizzaOrderSystem.Model.Topping
{
    public class FriedGarlic : Topping
    {
        private string _name = "フライドガーリック";
        private int _price = 150;

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
