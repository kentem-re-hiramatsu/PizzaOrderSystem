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
