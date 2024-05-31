using System;

namespace PizzaOrderSystem.Model.Topping
{
    public class FriedGarlic : Topping
    {
        private string _name = "フライドガーリック";
        private int _price = 150;

        public FriedGarlic() { }
        public FriedGarlic(int price)
        {
            if (price == 0)
            {
                _price = price;
            }
            throw new Exception(Consts.ERROR_MESSAGE_DEFAULT_PRICE);
        }
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
