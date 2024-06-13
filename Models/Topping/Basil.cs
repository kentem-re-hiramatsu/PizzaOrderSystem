using System;

namespace Models.Topping
{
    public class Basil : ToppingMenu
    {
        const int DEFAULT_PRICE = 100;
        const string NAME = "バジル";

        public Basil(int defaultPrice = DEFAULT_PRICE)
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
