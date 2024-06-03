using PizzaOrderSystem.Enum;
using PizzaOrderSystem.Model.Pizza;
using System;
namespace PizzaOrderSystem.Model.Topping
{
    public class Bacon : IMenuItem
    {
        private PizzaEnum _name = PizzaEnum.ベーコン;
        private int _price = (int)PizzaEnum.ベーコン;

        public Bacon() { }
        public Bacon(int defaultPrice)
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
