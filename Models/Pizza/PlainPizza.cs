using Models.Topping;

namespace Models.Pizza
{
    public class PlainPizza : PizzaMenu
    {
        public PlainPizza()
        {
            _name = "プレーンピザ";
            _price = 1200;
            SetDefaultTopping();
        }

        public override void SetDefaultTopping()
        {
            _toppingList.Add(new Cheese(0));
            _toppingList.Add(new Tomato(0));
        }
    }
}
