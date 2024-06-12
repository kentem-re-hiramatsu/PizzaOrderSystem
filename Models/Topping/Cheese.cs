using System;

namespace Models.Topping
{
    public class Cheese : ToppingMenu
    {
        const int DEFAULT_PRICE = 100;
        const string NAME = "チーズ";

        public Cheese(int defaultPrice = DEFAULT_PRICE)
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
