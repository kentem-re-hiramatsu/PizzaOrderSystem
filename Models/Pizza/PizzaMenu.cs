using Models.Topping;
using System.Collections.Generic;

namespace Models.Pizza
{
    public abstract class PizzaMenu : IMenuItem
    {
        protected string _name;
        protected int _price;
        protected List<IMenuItem> _toppingList = new List<IMenuItem>();

        public string Name { get { return _name; } }
        public int Price { get { return _price; } }

        public int GetCountToppingList()
        {
            return _toppingList.Count;
        }

        public IMenuItem GetTopping(int index)
        {
            return _toppingList[index];
        }

        public void SetTopping(ToppingMenu topping)
        {
            _toppingList.Add(topping);
        }

        public int GetTotalToppingPrice()
        {
            int totalPrice = 0;

            foreach (var item in _toppingList)
            {
                totalPrice += item.Price;
            }
            return totalPrice;
        }

        public abstract void SetDefaultTopping();
    }
}
