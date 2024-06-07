using System;

namespace Models.Topping
{
    public class FriedGarlic : ToppingMenu
    {
        public FriedGarlic(int defaultPrice = 150)
        {
            _name = "フライドガーリック";

            if (defaultPrice == -1)
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
