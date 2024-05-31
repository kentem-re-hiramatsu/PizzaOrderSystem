using PizzaOrderSystem.Model.Topping;
using System.Collections.Generic;

namespace PizzaOrderSystem.Model.Pizza
{
    public class SeafoodPizza : IMenuItem
    {
        string _name = "シーフードピザ";
        int _price = 1400;
        List<IMenuItem> _defaultToppingList = new List<IMenuItem>();

        public SeafoodPizza()
        {
            _defaultToppingList.Add(new Cheese(0));
            _defaultToppingList.Add(new SeafoodMix(0));
        }
        public int GetPrice()
        {
            return _price;
        }
        public string GetName()
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
