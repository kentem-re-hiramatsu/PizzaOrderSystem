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
