using PizzaOrderSystem.Model.Topping;
using System.Collections.Generic;

namespace PizzaOrderSystem.Model.Pizza
{
    public class PlainPizza : IMenuItem
    {
        string _name = "プレーンピザ";
        int _price = 1200;
        List<IMenuItem> _defaultToppingList = new List<IMenuItem>();

        public PlainPizza()
        {
            _defaultToppingList.Add(new Cheese(0));
            _defaultToppingList.Add(new Tomato(0));
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

        public IMenuItem GetDefaultToppingList(int index)
        {
            return _defaultToppingList[index];
        }
    }
}
