using System;

namespace Models.Topping
{
    public class Tuna : ToppingMenu
    {
        const int DEFAULTPRICE = 250;
        const string NAME = "ツナ";

        public Tuna(int defaultPrice = DEFAULTPRICE)
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
