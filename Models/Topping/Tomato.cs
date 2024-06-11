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
