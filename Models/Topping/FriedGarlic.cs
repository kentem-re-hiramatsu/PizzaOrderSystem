using System;

namespace Models.Topping
{
    public class FriedGarlic : ToppingMenu
    {
        private string _name = "フライドガーリック";
        private int _price = 150;

        public FriedGarlic() { }
        public FriedGarlic(int defaultPrice)
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
