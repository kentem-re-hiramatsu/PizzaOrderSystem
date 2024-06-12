using System;

namespace Models.Topping
{
    public class FriedGarlic : ToppingMenu
    {
        const int DEFAULT_PRICE = 150;
        const string NAME = "フライドガーリック";

        public FriedGarlic(int defaultPrice = DEFAULT_PRICE)
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
