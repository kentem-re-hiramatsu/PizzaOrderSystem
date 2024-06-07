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
