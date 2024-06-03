using Models.Topping;
using System.Collections.Generic;

namespace Models.Pizza
{
    public class SeafoodPizza : PizzaMenu
    {
        string _name = "シーフードピザ";
        int _price = 1400;
        List<IMenuItem> _defaultToppingList = new List<IMenuItem>();

        public SeafoodPizza()
        {
            _defaultToppingList.Add(new Cheese(0));
            _defaultToppingList.Add(new SeafoodMix(0));
        }
        public override int GetPrice()
        {
            return _price;
        }
        public override string GetName()
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
