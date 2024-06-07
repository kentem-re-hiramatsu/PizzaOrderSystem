using System;

namespace Models.Topping
{
    public class Scallops : ToppingMenu
    {
        const int DEFAULTPRICE = 500;
        const string NAME = "ホタテ";

        public Scallops(int defaultPrice = DEFAULTPRICE)
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
