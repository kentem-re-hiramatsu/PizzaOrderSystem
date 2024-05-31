using PizzaOrderSystem.Model.Pizza;
using System;

namespace PizzaOrderSystem.Model.Topping
{
    public class SeafoodMix : IMenuItem
    {
        private string _name = "シーフードミックス";
        private int _price = 500;

        public SeafoodMix() { }
        public SeafoodMix(int defaultPrice)
        {
            if (defaultPrice == 0)
            {
                _price = defaultPrice;
            }
            throw new Exception(Consts.ERROR_MESSAGE_DEFAULT_PRICE);
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
