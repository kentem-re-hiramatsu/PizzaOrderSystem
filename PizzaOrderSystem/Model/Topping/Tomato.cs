﻿using PizzaOrderSystem.Model.Pizza;
using System;

namespace PizzaOrderSystem.Model.Topping
{
    public class Tomato : IMenuItem
    {
        private string _name = "トマト";
        private int _price = 250;

        public Tomato() { }
        public Tomato(int defaultPrice)
        {
            if (defaultPrice == 0)
            {
                _price = defaultPrice;
            }
            throw new Exception(Consts.ERROR_MESSAGE_DEFAULT_PRICE);
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
