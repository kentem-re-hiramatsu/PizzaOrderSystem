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

        public abstract PizzaMenu DeepCopy();
        public string Name { get { return _name; } }
        public int Price { get { return _price; } }
        public IReadOnlyCollection<ToppingMenu> ToppingList { get { return _toppingList; } }

        public PizzaMenu()
        {
            SetDefaultTopping();
        }

        public ToppingMenu GetTopping(int index) => _toppingList[index];

        public void SetTopping(ToppingMenu topping) => _toppingList.Add(topping);

        public int GetPizzaTotalPrice() => _toppingList.Sum(topping => topping.Price) + _price;

        protected abstract void SetDefaultTopping();
    }
}
