using System;

namespace Models.Topping
{
    public class Scallops : ToppingMenu
    {
        public Scallops(int defaultPrice = 500)
        {
            _name = "ホタテ";

            if (defaultPrice == 0 || defaultPrice == 500)
            {
                _price = defaultPrice;
            }
            else
            {
                throw new Exception(Consts.ERROR_MESSAGE_DEFAULT_PRICE);
            }
        }
    }
}
