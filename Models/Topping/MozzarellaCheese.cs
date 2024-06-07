using System;

namespace Models.Topping
{
    public class MozzarellaCheese : ToppingMenu
    {
        public MozzarellaCheese(int defaultPrice = 300)
        {
            _name = "モッツァレラチーズ";

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
