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
