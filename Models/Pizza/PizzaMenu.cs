using Models.Topping;
using System.Collections.Generic;

namespace Models.Pizza
{
    public abstract class PizzaMenu : IMenuItem
    {
        protected string _name;
        protected int _price;
        protected List<ToppingMenu> _toppingList = new List<ToppingMenu>();

        public string Name { get { return _name; } }
        public int Price { get { return _price; } }
        public IReadOnlyCollection<ToppingMenu> ToppingList { get { return _toppingList; } }

        public PizzaMenu()
        {
            SetDefaultTopping();
        }

        public IMenuItem GetTopping(int index)
        {
            return _toppingList[index];
        }

        public void SetTopping(ToppingMenu topping)
        {
            _toppingList.Add(topping);
        }

        public int GetPizzaTotalPrice()
        {
            int totalPrice = 0;

            foreach (var topping in _toppingList)
            {
                totalPrice += topping.Price;
            }

            return totalPrice + _price;
        }

        public abstract void SetDefaultTopping();
    }
}
