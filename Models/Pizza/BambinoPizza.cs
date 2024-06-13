using Models.Topping;

namespace Models.Pizza
{
    public class BambinoPizza : PizzaMenu
    {
        const string NAME = "バンビーノピザ";
        const int DEFAULTPRICE = 1600;

        public BambinoPizza() : base()
        {
            _name = NAME;
            _price = DEFAULTPRICE;
        }

        public override PizzaMenu DeepCopy()
        {
            return new BambinoPizza();
        }

        protected override void SetDefaultTopping()
        {
            _toppingList.Add(new Cheese(0));
            _toppingList.Add(new Tomato(0));
            _toppingList.Add(new Tuna(0));
            _toppingList.Add(new Corn(0));
            _toppingList.Add(new Bacon(0));
        }
    }

}
