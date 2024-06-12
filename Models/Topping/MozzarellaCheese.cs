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

            if (defaultPrice < 0)
            {
                throw new Exception(Consts.ERROR_MESSAGE);
            }
            else
            {
                _price = defaultPrice;
            }
        }
    }
}
