using Models.Topping;

namespace Models.Pizza
{
    public class MargheritaPizza : PizzaMenu
    {
        public MargheritaPizza() : base()
        {
            _name = "マルゲリータピザ";
            _price = 1500;
        }

        public override void SetDefaultTopping()
        {
            _toppingList.Add(new Cheese(0));
            _toppingList.Add(new Tomato(0));
            _toppingList.Add(new MozzarellaCheese(0));
            _toppingList.Add(new Basil(0));
        }
    }
}
