using System;

namespace Models.Topping
{
    public class Tomato : ToppingMenu
    {
        const int DEFAULTPRICE = 250;
        const string NAME = "トマト";

        public Tomato(int defaultPrice = DEFAULTPRICE)
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
