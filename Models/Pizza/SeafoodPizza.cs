using Models.Topping;

namespace Models.Pizza
{
    public class SeafoodPizza : PizzaMenu
    {
        const string NAME = "シーフードピザ";
        const int DEFAULTPRICE = 1400;

        public SeafoodPizza() : base()
        {
            _name = NAME;
            _price = DEFAULTPRICE;
        }

        public override void SetDefaultTopping()
        {
            _toppingList.Add(new Cheese(0));
            _toppingList.Add(new SeafoodMix(0));
        }
    }
}
