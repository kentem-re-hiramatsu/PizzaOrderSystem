using Models.Topping;

namespace Models.Pizza
{
    public class PescaTorePizza : PizzaMenu
    {
        const string NAME = "ペスカトーレピザ";
        const int DEFAULTPRICE = 1800;

        public PescaTorePizza() : base()
        {
            _name = NAME;
            _price = DEFAULTPRICE;
        }

        public override PizzaMenu DeepCopy()
        {
            return new PescaTorePizza();
        }

        protected override void SetDefaultTopping()
        {
            _toppingList.Add(new Cheese(0));
            _toppingList.Add(new SeafoodMix(0));
            _toppingList.Add(new Scallops(0));
        }
    }
}
