using System;

namespace Models.Topping
{
    public class Tuna : ToppingMenu
    {
        public Tuna(int defaultPrice = 250)
        {
            _name = "ツナ";

            if (defaultPrice == 0 || defaultPrice == 250)
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
