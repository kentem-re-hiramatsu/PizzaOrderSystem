using System;

namespace Models.Topping
{
    public class SeafoodMix : ToppingMenu
    {
        public SeafoodMix(int defaultPrice = 500)
        {
            _name = "シーフードミックス";

            if (defaultPrice == 0 || defaultPrice == 500)
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
