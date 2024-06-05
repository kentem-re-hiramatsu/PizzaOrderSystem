using System;

namespace Models.Topping
{
    public class MozzarellaCheese : ToppingMenu
    {
        public MozzarellaCheese(int defaultPrice = 300)
        {
            _name = "モッツァレラチーズ";

            if (defaultPrice == 0 || defaultPrice == 300)
            {
                _price = defaultPrice;
            }
            else
            {
                throw new Exception(Consts.ERROR_MESSAGE_DEFAULT_PRICE);
            }
        }
    }
}
