using Models.Topping;
using System.Collections.Generic;
using System.Linq;

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

        public void Reamove(string name)
        {
            for (int i = 0; i < _toppingList.Count; i++)
            {
                if (_toppingList[i].Name == name)
                {
                    _toppingList.RemoveAt(i);
                }
            }
        }

        public int GetPizzaTotalPrice()
        {
            int totalPrice = _toppingList.Select(x => x.Price).Sum();

            return totalPrice + _price;
        }

        protected abstract void SetDefaultTopping();
    }
}
