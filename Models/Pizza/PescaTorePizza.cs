using Models.Topping;
using System.Collections.Generic;

namespace Models.Pizza
{
    public class PescaTorePizza : PizzaMenu
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
