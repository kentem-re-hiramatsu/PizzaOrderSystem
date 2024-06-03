using System;

namespace Models.Topping
{
    public class SeafoodMix : ToppingMenu
    {
        private string _name = "シーフードミックス";
        private int _price = 500;

        public SeafoodMix() { }
        public SeafoodMix(int defaultPrice)
        {
            if (defaultPrice != 0)
            {
                throw new Exception(Consts.ERROR_MESSAGE_DEFAULT_PRICE);
            }
            _price = defaultPrice;
        }

        public override string GetName()
        {
            return _name;
        }

        public override int GetPrice()
        {
            return _price;
        }
    }

}
