using System;

namespace Models.Topping
{
    public class Scallops : ToppingMenu
    {
        public Scallops(int defaultPrice = 500)
        {
            _name = "ホタテ";

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
