using System;

namespace Models.Topping
{
    public class MozzarellaCheese : ToppingMenu
    {
        const int DEFAULTPRICE = 300;
        const string NAME = "モッツァレラチーズ";

        public MozzarellaCheese(int defaultPrice = DEFAULTPRICE)
        {
            _name = NAME;

            if (defaultPrice != -1)
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
