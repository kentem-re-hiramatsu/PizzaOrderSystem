using PizzaOrderSystem.Model.Topping;
using System.Collections.Generic;

namespace PizzaOrderSystem.Model.Pizza
{
    public class PescaTorePizza : IMenuItem
    {
        string _name = "ペスカトーレピザ";
        int _price = 1800;
        List<IMenuItem> _defaultToppingList = new List<IMenuItem>();

        public PescaTorePizza()
        {
            _defaultToppingList.Add(new Cheese(0));
            _defaultToppingList.Add(new SeafoodMix(0));
            _defaultToppingList.Add(new Scallops(0));
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
