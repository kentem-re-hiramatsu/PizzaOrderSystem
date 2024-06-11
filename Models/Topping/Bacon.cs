using System;

namespace Models.Topping
{
    public class Bacon : ToppingMenu
    {
        const int DEFAULTPRICE = 250;
        const string NAME = "ベーコン";

        public Bacon(int defaultPrice = DEFAULTPRICE)
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
