using System;

namespace Models.Topping
{
    public class Bacon : ToppingMenu
    {
        public Bacon(int defaultPrice = 250)
        {
            _name = "ベーコン";

            if (defaultPrice == 0 || defaultPrice == 250)
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
