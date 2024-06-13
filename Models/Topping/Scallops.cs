using System;

namespace Models.Topping
{
    public class Scallops : ToppingMenu
    {
        const int DEFAULT_PRICE = 500;
        const string NAME = "ホタテ";

        public Scallops(int defaultPrice = DEFAULT_PRICE)
        {
            _name = NAME;

            if (defaultPrice > -1)
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
