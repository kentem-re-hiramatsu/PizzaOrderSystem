using PizzaOrderSystem.Enum;
using PizzaOrderSystem.Model.Pizza;
using System;

namespace PizzaOrderSystem.Model.Topping
{
    public class FriedGarlic : IMenuItem
    {
        private PizzaEnum _name = PizzaEnum.フライドガーリック;
        private int _price = 150;

        public FriedGarlic() { }
        public FriedGarlic(int defaultPrice)
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
