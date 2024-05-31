using System;

namespace PizzaOrderSystem.Model.Topping
{
    public class Cheese : Topping
    {
        private string _name = "チーズ";
        private int _price = 100;

        public Cheese() { }
        public Cheese(int price)
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
