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
