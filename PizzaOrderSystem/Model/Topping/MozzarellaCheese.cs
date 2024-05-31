using PizzaOrderSystem.Model.Pizza;
using System;

namespace PizzaOrderSystem.Model.Topping
{
    public class MozzarellaCheese : IMenuItem
    {
        private string _name = "モッツァレラチーズ";
        private int _price = 300;

        public MozzarellaCheese() { }
        public MozzarellaCheese(int defaultPrice)
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
