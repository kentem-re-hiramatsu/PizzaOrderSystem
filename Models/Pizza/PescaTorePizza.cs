using Models.Topping;

namespace Models.Pizza
{
    public class PescatorePizza : PizzaMenu
    {
        const string NAME = "ペスカトーレピザ";
        const int DEFAULTPRICE = 1800;

        public PescatorePizza() : base()
        {
            _name = NAME;
            _price = DEFAULTPRICE;
        }

        public override PizzaMenu Clone()
        {
            return new PescatorePizza();
        }

        protected override void SetDefaultTopping()
        {
            _toppingList.Add(new Cheese(0));
            _toppingList.Add(new SeafoodMix(0));
            _toppingList.Add(new Scallops(0));
        }
    }
}
