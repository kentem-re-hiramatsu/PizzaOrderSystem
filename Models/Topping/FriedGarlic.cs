using System;

namespace Models.Topping
{
    public class FriedGarlic : ToppingMenu
    {
        const int DEFAULTPRICE = 150;
        const string NAME = "フライドガーリック";

        public FriedGarlic(int defaultPrice = DEFAULTPRICE)
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
