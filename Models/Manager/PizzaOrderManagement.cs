using Models.Pizza;
using Models.Topping;
using System.Collections.Generic;

namespace Models.Manager
{
    public class PizzaOrderManagement
    {
        private List<ToppingOrderManagement> _pizzaOrderList;
        private List<PizzaMenu> _pizzaMenuList;
        private List<ToppingMenu> _toppingMenuList;

        public PizzaOrderManagement()
        {
            _pizzaOrderList = new List<ToppingOrderManagement>();
            _pizzaMenuList = new List<PizzaMenu>();
            _toppingMenuList = new List<ToppingMenu>();

            SetPizzaMenuList();
            SetToppingMenuList();
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
        public PizzaMenu GetPizzaMenu(int index)
        {
            return _pizzaMenuList[index];
        }
        private void SetPizzaMenuList()
        {
            _pizzaMenuList.Add(new PlainPizza());
            _pizzaMenuList.Add(new MargheritaPizza());
            _pizzaMenuList.Add(new SeafoodPizza());
            _pizzaMenuList.Add(new PescaTorePizza());
            _pizzaMenuList.Add(new BambinoPizza());
        }

        public int GetPizzaMenuListCount()
        {
            return _pizzaMenuList.Count;
        }

        public ToppingMenu GetToppingMenu(int index)
        {
            return _toppingMenuList[index];
        }

        public int GetToppingMenuListCount()
        {
            return _toppingMenuList.Count;
        }
        private void SetToppingMenuList()
        {
            _toppingMenuList.Add(new Cheese());
            _toppingMenuList.Add(new FriedGarlic());
            _toppingMenuList.Add(new MozzarellaCheese());
            _toppingMenuList.Add(new SeafoodMix());
            _toppingMenuList.Add(new Scallops());
            _toppingMenuList.Add(new Basil());
            _toppingMenuList.Add(new Tomato());
            _toppingMenuList.Add(new Tuna());
            _toppingMenuList.Add(new Corn());
            _toppingMenuList.Add(new Bacon());
        }
    }
}
