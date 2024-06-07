using System;

namespace Models.Topping
{
    public class Corn : ToppingMenu
    {
        public Corn(int defaultPrice = 250)
        {
            _name = "コーン";

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
