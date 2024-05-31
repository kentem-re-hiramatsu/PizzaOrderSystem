using System;

namespace PizzaOrderSystem.Model.Topping
{
    public class Basil : Topping
    {
        private string _name = "バジル";
        private int _price = 100;

        public Basil() { }
        public Basil(int price)
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
