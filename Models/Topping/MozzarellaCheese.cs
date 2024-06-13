using System;

namespace Models.Topping
{
    public class MozzarellaCheese : ToppingMenu
    {
        const int DEFAULT_PRICE = 300;
        const string NAME = "モッツァレラチーズ";

        public MozzarellaCheese(int defaultPrice = DEFAULT_PRICE)
        {
            _name = NAME;

            if (defaultPrice > -1)
            {
                _price = defaultPrice;
            }
            else
            {
                throw new Exception(Consts.ERROR_MESSAGE);
            }
        }
    }
}
