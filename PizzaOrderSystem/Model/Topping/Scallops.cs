using System;

namespace PizzaOrderSystem.Model.Topping
{
    public class Scallops : Topping
    {
        private string _name = "ホタテ";
        private int _price = 500;

        public Scallops() { }
        public Scallops(int price)
        {
            if (price == 0)
            {
                _price = price;
            }
            throw new Exception(Consts.ERROR_MESSAGE_DEFAULT_PRICE);
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
