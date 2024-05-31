﻿using PizzaOrderSystem.Model.Pizza;
using System;
namespace PizzaOrderSystem.Model.Topping
{
    public class Bacon : IMenuItem
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
        public string GetName()
        {
            return _name;
        }

        public int GetPrice()
        {
            return _price;
        }
    }
}