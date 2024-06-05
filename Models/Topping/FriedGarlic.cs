using System;

namespace Models.Topping
{
    public class FriedGarlic : ToppingMenu
    {
        public FriedGarlic(int defaultPrice = 150)
        {
            _name = "フライドガーリック";

            if (defaultPrice == 0 || defaultPrice == 150)
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
