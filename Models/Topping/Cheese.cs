using System;

namespace Models.Topping
{
    public class Cheese : ToppingMenu
    {
        const int DEFAULTPRICE = 100;
        const string NAME = "チーズ";

        public Cheese(int defaultPrice = DEFAULTPRICE)
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
