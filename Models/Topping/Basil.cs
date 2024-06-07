using System;

namespace Models.Topping
{
    public class Basil : ToppingMenu
    {
        public Basil(int defaultPrice = 100)
        {
            _name = "バジル";

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
