using System;

namespace Models.Topping
{
    public class Cheese : ToppingMenu
    {
        public Cheese(int defaultPrice = 100)
        {
            _name = "チーズ";

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
