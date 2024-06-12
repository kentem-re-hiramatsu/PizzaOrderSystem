using System;

namespace Models.Topping
{
    public class Tuna : ToppingMenu
    {
        const int DEFAULT_PRICE = 250;
        const string NAME = "ツナ";

        public Tuna(int defaultPrice = DEFAULT_PRICE)
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
