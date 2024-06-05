using Models.Topping;

namespace Models.Pizza
{
    public class BambinoPizza : PizzaMenu
    {
        public BambinoPizza()
        {
            _name = "バンビーノピザ";
            _price = 1600;
            SetDefaultTopping();
        }

        public override void SetDefaultTopping()
        {
            _defaultToppingList.Add(new Cheese(0));
            _defaultToppingList.Add(new Tomato(0));
            _defaultToppingList.Add(new Tuna(0));
            _defaultToppingList.Add(new Corn(0));
            _defaultToppingList.Add(new Bacon(0));
        }
    }

}
