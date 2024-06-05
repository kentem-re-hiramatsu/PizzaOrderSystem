using Models.Topping;
using System.Collections.Generic;

namespace Models.Pizza
{
    public class MargheritaPizza : PizzaMenu
    {
        string _name = "マルゲリータピザ";
        int _price = 1500;
        List<IMenuItem> _defaultToppingList = new List<IMenuItem>();

        public MargheritaPizza()
        {
            _defaultToppingList.Add(new Cheese(0));
            _defaultToppingList.Add(new Tomato(0));
            _defaultToppingList.Add(new MozzarellaCheese(0));
            _defaultToppingList.Add(new Basil(0));
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
