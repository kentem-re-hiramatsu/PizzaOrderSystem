using System;

namespace Models.Topping
{
    public class Cheese : ToppingMenu
    {
        public Cheese(int defaultPrice = 100)
        {
            _name = "チーズ";

            if (defaultPrice == 0 || defaultPrice == 100)
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
