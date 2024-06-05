using Models.Topping;

namespace Models.Pizza
{
    public class SeafoodPizza : PizzaMenu
    {
        public SeafoodPizza()
        {
            _name = "シーフードピザ";
            _price = 1400;
            SetDefaultTopping();
        }

        public override void SetDefaultTopping()
        {
            _defaultToppingList.Add(new Cheese(0));
            _defaultToppingList.Add(new SeafoodMix(0));
        }
    }

}
