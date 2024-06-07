using System;

namespace Models.Topping
{
    public class Basil : ToppingMenu
    {
        const int DEFAULTPRICE = 100;
        const string NAME = "バジル";

        public Basil(int defaultPrice = DEFAULTPRICE)
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
