using System;

namespace Models.Topping
{
    public class Corn : ToppingMenu
    {
        private string _name = "コーン";
        private int _price = 250;

        public Corn() { }
        public Corn(int defaultPrice)
        {
            if (defaultPrice != 0)
            {
                throw new Exception(Consts.ERROR_MESSAGE_DEFAULT_PRICE);
            }
            _price = defaultPrice;
        }
        public override string Name { get { return _name; } }
        public override int Price { get { return _price; } }
    }

}
