using System;

namespace Models.Topping
{
    public class Tomato : ToppingMenu
    {
        private string _name = "トマト";
        private int _price = 250;

        public Tomato() { }
        public Tomato(int defaultPrice)
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
