using Models.Topping;

namespace Models.Pizza
{
    public class PlainPizza : PizzaMenu
    {
        const string NAME = "プレーンピザ";
        const int DEFAULTPRICE = 1200;

        public PlainPizza() : base()
        {
            _name = NAME;
            _price = DEFAULTPRICE;
        }

        public override PizzaMenu Clone()
        {
            return new PlainPizza();
        }

        protected override void SetDefaultTopping()
        {
            _toppingList.Add(new Cheese(0));
            _toppingList.Add(new Tomato(0));
        }
    }
}
