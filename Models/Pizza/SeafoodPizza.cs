using Models.Topping;

namespace Models.Pizza
{
    public class SeafoodPizza : PizzaMenu
    {
        public SeafoodPizza() : base()
        {
            _name = "シーフードピザ";
            _price = 1400;
        }

        public override void SetDefaultTopping()
        {
            _toppingList.Add(new Cheese(0));
            _toppingList.Add(new SeafoodMix(0));
        }
    }
}
