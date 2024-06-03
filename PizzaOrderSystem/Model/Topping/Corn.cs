using PizzaOrderSystem.Enum;
using PizzaOrderSystem.Model.Pizza;
using System;

namespace PizzaOrderSystem.Model.Topping
{
    public class Corn : IMenuItem
    {
        private PizzaEnum _name = PizzaEnum.コーン;
        private int _price = 250;

        public Corn() { }
        public Corn(int defaultPrice)
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
