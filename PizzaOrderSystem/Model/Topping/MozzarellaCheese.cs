using System;

namespace PizzaOrderSystem.Model.Topping
{
    public class MozzarellaCheese : Topping
    {
        private string _name = "モッツァレラチーズ";
        private int _price = 300;

        public MozzarellaCheese() { }
        public MozzarellaCheese(int price)
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
