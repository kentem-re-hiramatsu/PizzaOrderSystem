using Models.Topping;
using System.Collections.Generic;

namespace Models.Pizza
{
    public class BambinoPizza : PizzaMenu
    {
        string _name = "バンビーノピザ";
        int _price = 1600;
        List<IMenuItem> _defaultToppingList = new List<IMenuItem>();

        public BambinoPizza() : base()
        {
            SetDefaultTopping();
        }

        public override string Name { get { return _name; } }
        public override int Price { get { return _price; } }
        public override int GetCountDefaultToppingList()
        {
            return _defaultToppingList.Count;
        }

        public override IMenuItem GetDefaultTopping(int index)
        {
            return _defaultToppingList[index];
        }

        public void SetDefaultTopping()
        {
            _defaultToppingList.Add(new Cheese(0));
            _defaultToppingList.Add(new Tomato(0));
            _defaultToppingList.Add(new Tuna(0));
            _defaultToppingList.Add(new Corn(0));
            _defaultToppingList.Add(new Bacon(0));
        }
    }

}
