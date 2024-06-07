using System;
namespace Models.Topping
{
    public class Tomato : ToppingMenu
    {
        public Tomato(int defaultPrice = 250)
        {
            _name = "トマト";

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
