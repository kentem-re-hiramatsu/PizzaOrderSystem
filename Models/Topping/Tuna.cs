using System;

namespace Models.Topping
{
    public class Tuna : ToppingMenu
    {
        public Tuna(int defaultPrice = 250)
        {
            _name = "ツナ";

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
