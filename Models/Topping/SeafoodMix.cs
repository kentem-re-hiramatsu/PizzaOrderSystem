using System;

namespace Models.Topping
{
    public class SeafoodMix : ToppingMenu
    {
        public SeafoodMix(int defaultPrice = 500)
        {
            _name = "シーフードミックス";

            if (defaultPrice == -1)
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
