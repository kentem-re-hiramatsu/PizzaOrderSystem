using System;
namespace Models.Topping
{
    public class Tomato : ToppingMenu
    {
        public Tomato(int defaultPrice = 250)
        {
            _name = "トマト";

            if (defaultPrice == 0 || defaultPrice == 250)
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
