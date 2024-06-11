using System;

namespace Models.Topping
{
    public class SeafoodMix : ToppingMenu
    {
        const int DEFAULTPRICE = 500;
        const string NAME = "シーフードミックス";

        public SeafoodMix(int defaultPrice = DEFAULTPRICE)
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
