using System;

namespace Models.Topping
{
    public class MozzarellaCheese : ToppingMenu
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
