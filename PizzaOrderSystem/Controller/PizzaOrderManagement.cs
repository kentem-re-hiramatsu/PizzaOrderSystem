using PizzaOrderSystem.Model.Pizza;
using System.Collections.Generic;

namespace PizzaOrderSystem.Controller
{
    public class PizzaOrderManagement
    {
        private List<IMenuItem> _pizzaOrderList = new List<IMenuItem>();
        private List<IMenuItem> _appendToppingList = new List<IMenuItem>();

        public PizzaOrderManagement()
        {
        }

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
    }
}
