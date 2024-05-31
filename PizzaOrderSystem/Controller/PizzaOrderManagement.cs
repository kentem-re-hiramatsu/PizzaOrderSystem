﻿using PizzaOrderSystem.Model.Pizza;
using System.Collections.Generic;

namespace PizzaOrderSystem.Controller
{
    public class PizzaOrderManagement
    {
        private List<IMenuItem> _pizzaOrderList = new List<IMenuItem>();
        private List<IMenuItem> _toppingOrderList = new List<IMenuItem>();

        public PizzaOrderManagement()
        {
        }

        //PizzaOrderList
        public void AddPizzaOrderList(IMenuItem pizzaMenu)
        {
            _pizzaOrderList.Add(pizzaMenu);
        }

        public IMenuItem GetPizzaOrder(int index)
        {
            return _pizzaOrderList[index];
        }

        public int GetPizzaOrderListCount()
        {
            return _pizzaOrderList.Count;
        }

        public void RemovePizzaOrderList(int index)
        {
            _pizzaOrderList.RemoveAt(index);
        }

        //ToppingOrderList
        public void AddToppingOrderList(IMenuItem pizzaMenu)
        {
            _toppingOrderList.Add(pizzaMenu);
        }

        public IMenuItem GetToppingOrderList(int index)
        {
            return _toppingOrderList[index];
        }

        public int GetToppingOrderListCount()
        {
            return _toppingOrderList.Count;
        }

        public void RemoveToppingOrderList(int index)
        {
            _toppingOrderList.RemoveAt(index);
        }
    }
}
