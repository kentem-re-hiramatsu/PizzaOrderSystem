using System;

namespace Models.Topping
{
    public class Bacon : ToppingMenu
    {
        private string _name = "ベーコン";
        private int _price = 250;

        public Bacon() { }
        public Bacon(int defaultPrice)
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
