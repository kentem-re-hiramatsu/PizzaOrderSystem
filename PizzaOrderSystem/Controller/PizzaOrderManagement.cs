using System.Collections.Generic;

namespace PizzaOrderSystem.Controller
{
    public class PizzaOrderManagement
    {
        private List<ToppingOrderManagement> _pizzaOrderList;

        public PizzaOrderManagement()
        {
            _pizzaOrderList = new List<ToppingOrderManagement>();
        }

        public void AddPizzaOrderList(ToppingOrderManagement pizzaMenu)
        {
            _pizzaOrderList.Add(pizzaMenu);
        }

        public ToppingOrderManagement GetPizzaOrder(int index)
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

        public int GetCalculatePizzaTotalPrice()
        {
            int totalPrice = 0;

            for (int i = 0; i < GetPizzaOrderListCount(); i++)
            {
                totalPrice += _pizzaOrderList[i].GetTotalToppingPrice();
            }

            return totalPrice;
        }
    }
}
