using PizzaOrderSystem.Enum;
using PizzaOrderSystem.Model.Pizza;
using System;

namespace PizzaOrderSystem.Model.Topping
{
    public class Tuna : IMenuItem
    {
        private PizzaEnum _name = PizzaEnum.ツナ;
        private int _price = (int)PizzaEnum.ツナ;

        public Tuna() { }
        public Tuna(int defaultPrice)
        {
            if (defaultPrice != 0)
            {
                throw new Exception(Consts.ERROR_MESSAGE_DEFAULT_PRICE);
            }
            _price = defaultPrice;
        }

        public PizzaEnum GetName()
        {
            return _name;
        }

        public int GetPrice()
        {
            return _price;
        }
    }
}
