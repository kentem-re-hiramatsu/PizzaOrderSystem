using System;

namespace Models.Topping
{
    public class Tuna : ToppingMenu
    {
        private string _name = "ツナ";
        private int _price = 250;

        public Tuna() { }
        public Tuna(int defaultPrice)
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
