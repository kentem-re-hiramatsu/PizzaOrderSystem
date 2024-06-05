using System;

namespace Models.Topping
{
    public class Basil : ToppingMenu
    {
        private string _name = "バジル";
        private int _price = 100;

        public Basil() { }
        public Basil(int defaultPrice)
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
