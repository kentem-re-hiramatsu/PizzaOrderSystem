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
