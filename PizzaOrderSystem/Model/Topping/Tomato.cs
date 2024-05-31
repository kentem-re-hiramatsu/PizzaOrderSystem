using System;

namespace PizzaOrderSystem.Model.Topping
{
    public class Tomato : Topping
    {
        private string _name = "トマト";
        private int _price = 250;

        public Tomato() { }
        public Tomato(int price)
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
