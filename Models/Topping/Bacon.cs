using System;

namespace Models.Topping
{
    public class Bacon : ToppingMenu
    {
        const int DEFAULT_PRICE = 250;
        const string NAME = "ベーコン";

        public Bacon(int defaultPrice = DEFAULT_PRICE)
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
