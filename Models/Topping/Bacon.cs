using System;

namespace Models.Topping
{
    public class Bacon : ToppingMenu
    {
        public Bacon(int defaultPrice = 250)
        {
            _name = "ベーコン";

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
