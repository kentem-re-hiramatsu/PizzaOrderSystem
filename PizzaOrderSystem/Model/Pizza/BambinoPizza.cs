using PizzaOrderSystem.Enum;
using PizzaOrderSystem.Model.Topping;
using System.Collections.Generic;

namespace PizzaOrderSystem.Model.Pizza
{
    public class BambinoPizza : IMenuItem
    {
        PizzaEnum _name = PizzaEnum.バンビーノピザ;
        int _price = (int)PizzaEnum.バンビーノピザ;
        List<IMenuItem> _defaultToppingList = new List<IMenuItem>();

        public BambinoPizza()
        {
            _defaultToppingList.Add(new Cheese(0));
            _defaultToppingList.Add(new Tomato(0));
            _defaultToppingList.Add(new Tuna(0));
            _defaultToppingList.Add(new Corn(0));
            _defaultToppingList.Add(new Bacon(0));
        }

        public int GetPrice()
        {
            return _price;
        }
        public PizzaEnum GetName()
        {
            return _name;
        }
        public int GetCountDefaultToppingList()
        {
            return _defaultToppingList.Count;
        }

        public IMenuItem GetDefaultTopping(int index)
        {
            return _defaultToppingList[index];
        }
    }
}
