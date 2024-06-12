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
