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
    }

}
