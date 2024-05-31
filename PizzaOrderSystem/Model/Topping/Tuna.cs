using System;

namespace PizzaOrderSystem.Model.Topping
{
    public class Tuna : Topping
    {
        private string _name = "ツナ";
        private int _price = 250;

        public Tuna() { }
        public Tuna(int price)
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
