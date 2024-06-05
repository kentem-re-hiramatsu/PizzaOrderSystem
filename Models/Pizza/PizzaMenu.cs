using System.Collections.Generic;

namespace Models.Pizza
{
    public abstract class PizzaMenu : IMenuItem
    {
        protected string _name;
        protected int _price;
        protected List<IMenuItem> _defaultToppingList = new List<IMenuItem>();

        public string Name { get { return _name; } }
        public int Price { get { return _price; } }

        public int GetCountDefaultToppingList()
        {
            return _defaultToppingList.Count;
        }

        public IMenuItem GetDefaultTopping(int index)
        {
            return _defaultToppingList[index];
        }

        public abstract void SetDefaultTopping();
    }
}
