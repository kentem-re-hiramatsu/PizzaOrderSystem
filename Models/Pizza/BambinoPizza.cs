using Models.Topping;

namespace Models.Pizza
{
    public class BambinoPizza : PizzaMenu
    {
        public BambinoPizza() : base()
        {
            _name = "バンビーノピザ";
            _price = 1600;
        }

        public override void SetDefaultTopping()
        {
            _toppingList.Add(new Cheese(0));
            _toppingList.Add(new Tomato(0));
            _toppingList.Add(new Tuna(0));
            _toppingList.Add(new Corn(0));
            _toppingList.Add(new Bacon(0));
        }
    }

}
