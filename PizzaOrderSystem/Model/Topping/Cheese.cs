using PizzaOrderSystem.Model.Pizza;
using System;

namespace PizzaOrderSystem.Model.Topping
{
    public class Cheese : IMenuItem
    {
        private string _name = "チーズ";
        private int _price = 100;

        public Cheese() { }
        public Cheese(int defaultPrice)
        {
            if (defaultPrice != 0)
            {
                throw new Exception(Consts.ERROR_MESSAGE_DEFAULT_PRICE);
            }
            _price = defaultPrice;
        }
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
