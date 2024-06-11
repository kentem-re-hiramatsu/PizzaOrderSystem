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
