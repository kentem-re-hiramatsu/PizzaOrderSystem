using System;

namespace Models.Topping
{
    public class Cheese : ToppingMenu
    {
        private string _name = "チーズ";
        private int _price = 100;

        public Cheese() { }
        public Cheese(int defaultPrice)
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
