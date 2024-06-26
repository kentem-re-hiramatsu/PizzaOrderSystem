﻿using System;

namespace Models.Topping
{
    public class SeafoodMix : ToppingMenu
    {
        const int DEFAULT_PRICE = 500;
        const string NAME = "シーフードミックス";

        public SeafoodMix(int defaultPrice = DEFAULT_PRICE)
        {
            _name = NAME;

            if (defaultPrice > -1)
            {
                _price = defaultPrice;
            }
            else
            {
                throw new Exception(Consts.ERROR_MESSAGE);
            }
        }
    }
}
